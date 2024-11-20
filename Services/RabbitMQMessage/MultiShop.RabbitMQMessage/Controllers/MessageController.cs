﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MultiShop.RabbitMQMessage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        [HttpPost]
        public  IActionResult CreateMessage()
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost",
            };

            var connection =  connectionFactory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare("Kuyruk2", false, false, arguments: null);
            var messageContent = "Merhaba bugün hava çok soğuk";
            var bytemessageContent = Encoding.UTF8.GetBytes(messageContent);
            channel.BasicPublish(exchange:"" , routingKey:"Kuyruk2" , basicProperties:null,body:bytemessageContent);
           
            return Ok("Mesajınız kuyruğa alınmıştır.");
        }
        private static string message;
        [HttpGet]
        public IActionResult ReadMessage()
        {
          
            var factory = new ConnectionFactory();
            factory.HostName = "localhost";
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var consumer = new EventingBasicConsumer(channel);
            channel.BasicConsume(queue: "Kuyruk2", autoAck: false, consumer: consumer);
            consumer.Received += (model, x) =>
            {
                var byteMessage = x.Body.ToArray();
                message = Encoding.UTF8.GetString(byteMessage);
               

            };
           
            if (string.IsNullOrEmpty(message))
            {
                return NoContent();
            }
            else
            {
                return Ok(message);
            }
            

        }
    }
}
