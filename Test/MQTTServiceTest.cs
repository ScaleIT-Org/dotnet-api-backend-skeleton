using System;
using dotnet_api_backend_skeleton.Logic;
using Xunit;

namespace dotnet_api_backend_skeleton.Test
{
    public class MQTTServiceTest
    {
        private readonly MQTTMessageLogic messageLogic;

        public MQTTServiceTest() 
        {
            messageLogic = new MQTTMessageLogic(); 
        } 
        
        #region Sample_TestCode
        [Fact]
        // [Theory]
        // [InlineData(-1)]
        // [InlineData(0)]
        // [InlineData(1)]
        public void TestOnlineConnection()
        {
            //This does not use Mocks and will try to contact the server directly
            MQTTMessageLogic.TestMQTTConnectionWithPublicBroker();
            Console.WriteLine("Mata");
            // Assert.True(false);
            // Assert.False(result, $"{value} should not be prime");
        }
        #endregion
        
      
    }
}
