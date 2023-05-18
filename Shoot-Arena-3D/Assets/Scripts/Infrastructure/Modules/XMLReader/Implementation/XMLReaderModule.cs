using System;
using System.Xml;
using ModestTree;
using ShootArena.Infrastructure.Modules.AssetProvider;
using ShootArena.Infrastructure.Modules.CustomLogger;
using ShootArena.Infrastructure.Modules.XMLReader.Data;
using ShootArena.Infrastructure.MonoComponents.StaticContainers.Contianers.Scenario;
using ShootArena.Infrastructure.MonoComponents.StaticContainers.Data.Scenario;
using UnityEngine;

namespace ShootArena.Infrastructure.Modules.XMLReader.Implementation
{
    public class XMLReaderModule : IXMLReaderModule
    {
        private readonly ICustomLoggerModule _logger = null;
        private readonly IAssetProviderModule _assetProvider = null;
        private readonly ScenarioStaticDataContainer _scenarioStaticDataContainer = null;
        private XmlDocument _currentXmlDocument = null;
        private TextAsset _currentTextAsset = null;

        public XMLReaderModule(
            ICustomLoggerModule logger,
            IAssetProviderModule assetProvider,
            ScenarioStaticDataContainer staticDataContainer)
        {
            _currentXmlDocument = new XmlDocument();
            _logger = logger;
            _assetProvider = assetProvider;
            _scenarioStaticDataContainer = staticDataContainer;
        }
        
        /*
         *  Helper Methods
         */
        
        private void PrepareCurrentScenario(XMLScenarioType scenarioType)
        {
            ScenarioStaticData scenarioModel = _scenarioStaticDataContainer.GetScenarioByType(scenarioType);

            if (scenarioModel == null)
            {
                _logger.LogError("XML Reader",$"[NULL] There is no scenario of type {scenarioType}");
                return;
            }

            string scenarioPath = scenarioModel.ScenarioPath;
            LoadTextAsset(scenarioPath);
            ReadCurrentXMLDocument();
        }

        private void LoadTextAsset(string assetPath)
        {
            _currentTextAsset = _assetProvider.GetAsset<TextAsset>(assetPath);

            if (_currentTextAsset == null)
            {
                _logger.LogError("XML Reader",$"[NULL] Asset at path - {assetPath} is null");
                return;
            }

            if (_currentTextAsset.text.IsEmpty())
            {
                _logger.LogError("XML Reader",$"[EMPTY] Asset at path - {assetPath} is empty");
                return;
            }
        }

        private void ReadCurrentXMLDocument()
        {
            if (_currentTextAsset != null 
                && !_currentTextAsset.text.IsEmpty())
            {
                _currentXmlDocument.LoadXml(_currentTextAsset.text);
            }
        }
        
        private T ParseNodeAttribute<T>(XmlNode node, string attributeName)
        {
            var tempAttribute = ReturnNodeAttribute(node, attributeName);

            T result = default;
            
            switch (Type.GetTypeCode(typeof(T)))
            {
                case TypeCode.Int32:
                    int intVal = (int)Convert.ChangeType(tempAttribute.Value, typeof(int));
                    result = (T)Convert.ChangeType(intVal, typeof(T));
                    break;
                case TypeCode.Single:
                    float floatVal = (float) Convert.ChangeType(tempAttribute.Value, typeof(float));
                    result = (T) Convert.ChangeType(floatVal, typeof(T));
                    break;
                case TypeCode.Boolean:
                    bool boolVal = (bool)Convert.ChangeType(tempAttribute.Value, typeof(bool));
                    result = (T) Convert.ChangeType(boolVal, typeof(T));
                    break;
                case TypeCode.String:
                    string stringVal = (string) Convert.ChangeType(tempAttribute.Value, typeof(string));
                    result = (T)Convert.ChangeType(stringVal, typeof(T));
                    break;
                case TypeCode.Object:
                    result = (T)Convert.ChangeType(tempAttribute.Value, typeof(T));
                    break;
                default:
                    _logger.LogError("XML Reader",$"Not supported type for parse: '{typeof(T).Name}' for attribute '{tempAttribute.Value}'");
                    break;
            }

            return result;
        }
        
        private XmlNode ReturnNodeAttribute(XmlNode parentNode, string attributeName)
        {
            if (parentNode != null)
                return parentNode.Attributes.GetNamedItem(attributeName);

            _logger.LogError("XML Reader",$"While returning {attributeName} null Exception was caught");
            return null;
        }
    }
}