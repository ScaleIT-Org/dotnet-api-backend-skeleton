using System;
using dotnet_api_backend_skeleton.Utilities;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace dotnet_api_backend_skeleton.Logic {
  public class MQTTMessageLogic {

    public static void TestMQTTConnectionWithPublicBroker(){
        ScaleITMQTTConnection conn = new ScaleITMQTTConnection("broker.hivemq.com", 1883);

        try {
            conn.ConnectWithID("ScaleITTestClient");
        }
        catch (uPLibrary.Networking.M2Mqtt.Exceptions.MqttConnectionException e)
        {
            Console.WriteLine("Some problem with the connection occured. Maybe it timed out, check the address. Here is the exception in full:");
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
        }

        string[] topics = { "sensor/temp", "sensor/humidity" };
        byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE };

        conn.Subscribe(topics, qosLevels);

        string temp = "9.0F";
        conn.PublishMessage(topics[0], temp);

        System.Threading.Thread.Sleep(2000);
        conn.Unsubscribe();
    }

  }
}
