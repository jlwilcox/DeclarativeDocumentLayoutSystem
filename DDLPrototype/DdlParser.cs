namespace DeclarativeLayout
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Xml;
    using DeclarativeLayout.Structs;

    public static class DdlParser
    {
        public static Grid LoadGrid(string filename)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filename);

            XmlElement gridXml = xmlDocument.DocumentElement;

            Grid grid = new Grid();
            SetProperties(grid, gridXml);

            ReadNode(gridXml.ChildNodes, grid);

            return grid;
        }

        private static void ReadNode(XmlNodeList nodeList, IParent parentPanel)
        {
            foreach (XmlNode xmlNode in nodeList)
            {
                if (xmlNode.NodeType == XmlNodeType.Element)
                {
                    Console.WriteLine(xmlNode.NodeType.ToString() + ": " + xmlNode.Name);

                    // Downcast demo
                    IElement element = LoadElement((XmlElement)xmlNode);

                    if (xmlNode.HasChildNodes)
                    {
                        if (element is IParent)
                        {
                            // panel / has children
                            // downcast
                            ReadNode(xmlNode.ChildNodes, (IParent)element);
                        }
                    }

                    parentPanel.Children.Add(element);
                }
            }
        }

        private static IElement LoadElement(XmlElement xmlElement)
        {
            Type foundType = FindType(xmlElement.Name);

            IElement element = (IElement)Activator.CreateInstance(foundType);

            // set respective properties
            SetProperties(element, xmlElement);

            return element;
        }

        private static void SetProperties(IElement element, XmlElement xmlElement)
        {
            PropertyInfo[] propertyInfos = element.GetType().GetProperties();

            // set default property
            if (element.DefaultProperty != null)
            {
                FindAndSetProperty(element, propertyInfos, element.DefaultProperty, xmlElement.InnerText);
            }

            foreach (XmlAttribute attribute in xmlElement.Attributes)
            {
                Console.WriteLine("Attribute: " + attribute.Name);

                if (attribute.Name.Contains("."))
                {
                    // This means it is an attached property
                    if (element is IAttachedProperties)
                    {
                        // Element supports attached property
                        string propertyName = attribute.Name.Split('.')[1];
                        string elementName = attribute.Name.Split('.')[0];
                        FindAndSetAttachedProperty((IAttachedProperties)element, elementName, propertyName, attribute.Value);
                    }
                }
                else
                {
                    // traditional property
                    // set property
                    FindAndSetProperty(element, propertyInfos, attribute.Name, attribute.Value);
                }
            }
        }

        private static void FindAndSetProperty(IElement element, PropertyInfo[] propertyInfos, string propertyName, string attributeValue)
        {
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                if (propertyInfo.Name == propertyName)
                {
                    Console.WriteLine("Property found: " + propertyInfo.Name);

                    // Convert to correct object
                    object value = ConvertValue(attributeValue, propertyInfo.PropertyType);

                    // Set value
                    propertyInfo.SetValue(element, value);
                }
            }
        }

        private static void FindAndSetAttachedProperty(IAttachedProperties element, string targetElementName, string propertyName, string attributeValue)
        {
            // find element
            Type targetElement = FindType(targetElementName);

            // find attached property
            IAttachableProperty attachedProperty = GlobalAttachedPropertyManager.GetAttachedProperty(propertyName, targetElement);

            // Get attribute value
            object value = ConvertValue(attributeValue, attachedProperty.PropertyType);

            // Set attached property
            element.SetAttachedProperty(attachedProperty, value);
        }

        private static object ConvertValue(string attributeValue, Type propertyType)
        {
            object value = null;

            if (propertyType == typeof(string))
            {
                value = attributeValue;
            }
            else if (propertyType == typeof(int))
            {
                value = Convert.ToInt32(attributeValue);
            }
            else if (propertyType == typeof(double))
            {
                value = Convert.ToDouble(attributeValue);
            }
            else if (propertyType == typeof(bool))
            {
                value = Convert.ToBoolean(attributeValue);
            }
            else if (propertyType == typeof(Thickness))
            {
                value = StringToThickness(attributeValue);
            }
            else if (propertyType == typeof(Color))
            {
                value = HexStringToColor(attributeValue);
            }
            else if (propertyType == typeof(Dock))
            {
                value = StringToDock(attributeValue);
            }
            else if (propertyType == typeof(HorizontalAlignment))
            {
                value = StringToHorizontalAlignment(attributeValue);
            }
            else if (propertyType == typeof(StretchMode))
            {
                value = StringToStretchMode(attributeValue);
            }

            if (value == null)
            {
                throw new ArgumentException("Unsupported type.");
            }

            return value;
        }

        private static Type FindType(string typeName)
        {
            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass
                    select t;

            List<Type> types = q.ToList();

            foreach (Type type in types)
            {
                if (type.Name == typeName)
                {
                    return type;
                }
            }

            throw new InvalidOperationException("Element could not be found");
        }

        private static Thickness StringToThickness(string thicknessString)
        {
            // Format "left top right bottom"
            string[] thicknesses = thicknessString.Split(' ');

            if (thicknesses.Length != 4)
            {
                throw new ArgumentException("Invalid thickness. Thickness must be specified for each side.");
            }

            Thickness thickness = new Thickness();

            try
            {
                thickness.Left = Convert.ToInt32(thicknesses[0]);
                thickness.Top = Convert.ToInt32(thicknesses[1]);
                thickness.Right = Convert.ToInt32(thicknesses[2]);
                thickness.Bottom = Convert.ToInt32(thicknesses[3]);
            }
            catch (FormatException ex)
            {
                throw new ArgumentException("Invalid thickness. Could not convert at least one side to integer.", ex);
            }

            return thickness;
        }

        private static Color HexStringToColor(string hexString)
        {
            // Format #hex colour string
            try
            {
                System.Drawing.Color drawingColor = System.Drawing.ColorTranslator.FromHtml(hexString);
                Color color = new Color(drawingColor.A, drawingColor.R, drawingColor.G, drawingColor.B);

                return color;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Cannot convert HEX to RGB colour.", ex);
            }
        }

        private static Dock StringToDock(string dockString)
        {
            dockString = dockString.ToLower();

            switch (dockString)
            {
                case "bottom":
                    return Dock.Bottom;
                case "left":
                    return Dock.Left;
                case "right":
                    return Dock.Right;
                case "top":
                    return Dock.Top;
            }

            throw new ArgumentException("Cannot convert to dock position.");
        }

        private static HorizontalAlignment StringToHorizontalAlignment(string alignmentString)
        {
            alignmentString = alignmentString.ToLower();

            switch (alignmentString)
            {
                case "left":
                    return HorizontalAlignment.Left;
                case "right":
                    return HorizontalAlignment.Right;
                case "center":
                    return HorizontalAlignment.Center;
                case "stretch":
                    return HorizontalAlignment.Stretch;
            }

            throw new ArgumentException("Cannot convert to horizontal alignment.");
        }

        private static StretchMode StringToStretchMode(string stretchModeString)
        {
            stretchModeString = stretchModeString.ToLower();

            switch (stretchModeString)
            {
                case "fill":
                    return StretchMode.Fill;
                case "none":
                    return StretchMode.None;
                case "uniform":
                    return StretchMode.Uniform;
                case "uniformtofill":
                    return StretchMode.UniformToFill;
            }

            throw new ArgumentException("Cannot convert to horizontal alignment.");
        }
    }
}
