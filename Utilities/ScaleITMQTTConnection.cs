using System;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace dotnet_api_backend_skeleton.Utilities
{
    internal class ScaleITMQTTConnection
    {
        // private string brokerHostName;
        // private int brokerPort;
        //https://m2mqtt.wordpress.com/using-mqttclient/

        private MqttClient client;
        private string[] topics;
        private byte[] qosLevels;

        public ScaleITMQTTConnection(string brokerHostName, int brokerPort)
        {
            client = new MqttClient(brokerHostName, brokerPort, false, null, null, MqttSslProtocols.None);
            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            //ubscription and/or unsubscription to a topic is completed and registered to the broker
            client.MqttMsgSubscribed += client_MqttMsgSubscribed;
            client.MqttMsgUnsubscribed += client_MqttMsgUnsubscribed;
            //will be delivered (exactly once) to all subscribers on the topic
            client.MqttMsgPublished += client_MqttMsgPublished;
        }

        internal void Subscribe(string[] topics, byte[] qosLevels)
        {
            this.topics = topics;
            this.qosLevels = qosLevels;
            client.Subscribe(topics, qosLevels);
        }

        internal void PublishMessage(string topic, string data)
        {
            client.Publish(topic, Encoding.UTF8.GetBytes(data));
            System.Console.WriteLine("Publishing message on {0} with data: {1}", topic, data);
        }

        internal void Unsubscribe()
        {
            client.Unsubscribe(topics);
        }

        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            // access data bytes throug e.Message
            System.Console.WriteLine("Message received with ID: " + Encoding.UTF8.GetString(e.Message));
        }

        void client_MqttMsgUnsubscribed(object sender, MqttMsgUnsubscribedEventArgs e)
        {
            System.Console.WriteLine("MqttMsgUnsubscribedEventArgs: " + e.MessageId.ToString());
        }

        void client_MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
        {
            System.Console.WriteLine("MqttMsgSubscribedEventArgs: " + e.MessageId.ToString());
        }

        void client_MqttMsgPublished(object sender, MqttMsgPublishedEventArgs e)
        {
            System.Console.WriteLine("MqttMsgPublishedEventArgs: " + e.MessageId);
        }

        public void ConnectWithID(string id)
        {
            client.Connect(id);
        }
    }
}