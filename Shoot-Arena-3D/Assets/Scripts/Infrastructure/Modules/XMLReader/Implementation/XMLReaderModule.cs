using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using ModestTree;
using ShootArena.Infrastructure.Core.Enemies.Data.Configuration;
using ShootArena.Infrastructure.Core.Enemies.Data.Types;
using ShootArena.Infrastructure.Core.Level.Data;
using ShootArena.Infrastructure.Core.Player.Data.Configuration;
using ShootArena.Infrastructure.Modules.AssetProvider;
using ShootArena.Infrastructure.Modules.CustomLogger;
using ShootArena.Infrastructure.Modules.XMLReader.Data;
using ShootArena.Infrastructure.MonoComponents.StaticContainers.Containers.Scenario;
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
         *  Public
         */

        public ILevelConfigurationData ReadLevelScenario()
        {
            PrepareCurrentScenario(XMLScenarioType.Level);
            
            XmlNode parentNode = _currentXmlDocument.SelectSingleNode("level");

            ILevelConfigurationData result = ParseLevelConfig(parentNode);
            
            return result;
        }

        public IPlayerConfigurationData ReadPlayerScenario()
        {
            PrepareCurrentScenario(XMLScenarioType.Player);
            
            XmlNode parentNode = _currentXmlDocument.SelectSingleNode("player");

            IPlayerConfigurationData result = ParsePlayerConfig(parentNode);
            
            return result;
        }

        public List<IEnemyConfigurationData> ReadEnemyScenario()
        {
            PrepareCurrentScenario(XMLScenarioType.Enemies);
            
            List<IEnemyConfigurationData> result = new List<IEnemyConfigurationData>();
            XmlNode parentNode = _currentXmlDocument.SelectSingleNode("enemies");

            foreach (XmlNode enemyNode in parentNode.ChildNodes)
            {
                IEnemyConfigurationData tempEnemy = ParseEnemyNode(enemyNode);
                
                result.Add(tempEnemy);
            }

            return result;
        }
        
        /*
         *  Private
         */

        private ILevelConfigurationData ParseLevelConfig(XmlNode parentNode)
        {
            ILevelConfigurationData result;
            
            string enemyTypesNodeName = "enemyTypes";
            string startRespawnRateNodeName = "startRespawnRate";
            string minRespawnRateNodeName = "minRespawnRate";
            string spawnDecreaseStepNodeName = "spawnDecreaseStep";
            string totalEnemiesCountPerRespawnNodeName = "totalEnemiesCountPerRespawn"; 
            string meleeEnemiesPerRespawnNodeName = "meleeEnemiesPerRespawn"; 
            string rangeEnemiesPerRespawnNodeName = "rangeEnemiesPerRespawn"; 
            

            EnemyType enemyTypes = (EnemyType)Enum.Parse(typeof(EnemyType),  ParseNodeAttribute<string>(parentNode, enemyTypesNodeName));
            float startRespawnRate = ParseNodeAttribute<float>(parentNode, startRespawnRateNodeName);
            float minRespawnRate = ParseNodeAttribute<float>(parentNode, minRespawnRateNodeName);
            float spawnDecreaseStep = ParseNodeAttribute<float>(parentNode, spawnDecreaseStepNodeName);
            int totalEnemiesCountPerRespawn = ParseNodeAttribute<int>(parentNode, totalEnemiesCountPerRespawnNodeName);
            int meleeEnemiesPerRespawn = ParseNodeAttribute<int>(parentNode, meleeEnemiesPerRespawnNodeName);
            int rangeEnemiesPerRespawn = ParseNodeAttribute<int>(parentNode, rangeEnemiesPerRespawnNodeName);

            result = new LevelConfigurationData
            (
                enemyTypes: enemyTypes,
                startRespawnRate: startRespawnRate,
                minRespawnRate: minRespawnRate,
                spawnDecreaseStep: spawnDecreaseStep,
                totalEnemiesCountPerRespawn: totalEnemiesCountPerRespawn,
                meleeCountAtLevelValue: meleeEnemiesPerRespawn,
                rangeCountAtLevelValue: rangeEnemiesPerRespawn
            );
            
            return result;
        }

        private IEnemyConfigurationData ParseEnemyNode(XmlNode enemyNode)
        {
            IEnemyConfigurationData result;
            
            string enemyTypeNodeName = "type";
            string attackTypeNodeName = "attackType";
            string moveSpeedNodeName = "moveSpeed";
            string maxHealthValueNodeName = "maxHealthValue";
            string dealDamageValueNodeName = "dealDamageValue";
            string rewardedPointsNodeName = "rewardedPoints";
            string attackIntervalValueNodeName = "attackIntervalValue";
            string attackRangeValueNodeName = "attackRangeValue";
            string jumpHeightValueNodeName = "jumpHeight";
            string attackSpeedValueNodeName = "attackSpeed";
            
            EnemyType enemyType = (EnemyType)Enum.Parse(typeof(EnemyType),  ParseNodeAttribute<string>(enemyNode, enemyTypeNodeName));
            EnemyAttackType attackType = (EnemyAttackType)Enum.Parse(typeof(EnemyAttackType),  ParseNodeAttribute<string>(enemyNode, attackTypeNodeName));
            float moveSpeed = ParseNodeAttribute<float>(enemyNode, moveSpeedNodeName);
            float maxHealthValue = ParseNodeAttribute<float>(enemyNode, maxHealthValueNodeName);
            float dealDamageValue = ParseNodeAttribute<float>(enemyNode, dealDamageValueNodeName);
            float pointsPerEnemyValue = ParseNodeAttribute<float>(enemyNode, rewardedPointsNodeName);
            float attackIntervalValue = ParseNodeAttribute<float>(enemyNode, attackIntervalValueNodeName);
            float attackRangeValue = ParseNodeAttribute<float>(enemyNode, attackRangeValueNodeName);
            float jumpHeightValue = ParseNodeAttribute<float>(enemyNode, jumpHeightValueNodeName);
            float attackSpeedValue = ParseNodeAttribute<float>(enemyNode, attackSpeedValueNodeName);
                
            result = new EnemyConfigurationData
            (
                enemyType: enemyType,
                attackType: attackType,
                enemyMoveSpeed: moveSpeed,
                enemyMaxHealth: maxHealthValue,
                enemyDealDamageValue: dealDamageValue,
                pointPerEnemyValue: pointsPerEnemyValue,
                enemyAttackIntervalValue: attackIntervalValue,
                enemyAttackRangeValue: attackRangeValue,
                enemyJumpHeight: jumpHeightValue,
                enemyAttackSpeed: attackSpeedValue
            );
            
            return result;
        }

        private IPlayerConfigurationData ParsePlayerConfig(XmlNode parentNode)
        {
            IPlayerConfigurationData result;
            
            string playerMoveSpeedNodeName = "moveSpeed";
            string playerRotationSpeedNodeName = "rotationSpeed";
            string minRotateHeightNodeName = "minRotateHeight";
            string maxRotateHeightNodeName = "maxRotateHeight";
            string playerShootRateNodeName = "shootRate";
            string playerStartHealthNodeName = "startHealthValue";
            string playerMaxHealthNodeName = "maxHealthValue";
            string playerStartStrengthNodeName = "startStrengthValue";
            string playerMaxStrengthNodeName = "maxStrengthValue";

            float playerMoveSpeed = ParseNodeAttribute<float>(parentNode, playerMoveSpeedNodeName);
            float playerRotationSpeed = ParseNodeAttribute<float>(parentNode, playerRotationSpeedNodeName);
            float playerRotationMinHeight = ParseNodeAttribute<float>(parentNode, minRotateHeightNodeName);
            float playerRotationMaxHeight = ParseNodeAttribute<float>(parentNode, maxRotateHeightNodeName);
            float playerShootRate = ParseNodeAttribute<float>(parentNode, playerShootRateNodeName);
            float playerStartHealthRate = ParseNodeAttribute<float>(parentNode, playerStartHealthNodeName);
            float playerMaxHealthRate = ParseNodeAttribute<float>(parentNode, playerMaxHealthNodeName);
            float playerStartStrengthRate = ParseNodeAttribute<float>(parentNode, playerStartStrengthNodeName);
            float playerMaxStrengthRate = ParseNodeAttribute<float>(parentNode, playerMaxStrengthNodeName);

            result = new PlayerConfigurationData
            (
                playerMoveSpeed: playerMoveSpeed,
                playerRotationSpeed: playerRotationSpeed,
                playerMinRotateHeight: playerRotationMinHeight,
                playerMaxRotateHeight: playerRotationMaxHeight,
                playerShootRate: playerShootRate,
                playerStartHealthValue: playerStartHealthRate,
                playerMaxHealthValue: playerMaxHealthRate,
                playerStartStrengthValue: playerStartStrengthRate,
                playerMaxStrengthValue: playerMaxStrengthRate
            );

            return result;
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
                    float floatVal;// = (float) Convert.ChangeType(tempAttribute.Value, typeof(float));
                    float.TryParse(node.Attributes.GetNamedItem(attributeName).Value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out floatVal);
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