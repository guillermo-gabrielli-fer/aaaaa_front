﻿using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    class Program
    {
        public static IBLTablero blHandler;

        static void Main(string[] args)
        {
            SetupDependencies();
            SetupService();
        }

        private static void SetupDependencies()
        {
            blHandler = new BLTablero(new DataAccessLayer.DALTablero());
        }

        private static void SetupService()
        {
            Uri baseAddress = new Uri("http://localhost:8836/tsi/");
            ServiceHost selfHost = new ServiceHost(typeof(ServiceTablero), baseAddress);
            try
            {
                selfHost.AddServiceEndpoint(
                        typeof(IServiceTablero),
                        new BasicHttpBinding(),
                        "ServiceTablero");
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);
                selfHost.Open();
                Console.WriteLine("Hola");
                Console.ReadLine();
                selfHost.Close();
            }catch (CommunicationException ce)
            {
                Console.Write("An exception ocurred: ", ce.Message);
                selfHost.Abort();
            }
        }
    }
}
