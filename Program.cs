using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisTesting
{
    class Program
    {
        /*
         *   - Need to be published
         *   - Can't run in local environment but an EC2 inside VPC
         *  
         */

        static void Main(string[] args)

        {

            try
            {
                string host = "wontokone-ga.bnadfg.ng.0001.apse2.cache.amazonaws.com:6379";

                string key = "IDG";

                // Store data in the cache
                Console.WriteLine($"Save into cache host...: {host}");

                bool success = Save(host, key, "Hello World!");

                // Retrieve data from the cache using the key

                Console.WriteLine("Success: Data retrieved from Redis Cache: " + Get(host, key));

            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e}");
            }

            Console.Read();

        }
        private static bool Save(string host, string key, string value)

        {

            bool isSuccess = false;

            using (RedisClient redisClient = new RedisClient(host))

            {

                if (redisClient.Get<string>(key) == null)

                {

                    isSuccess = redisClient.Set(key, value);

                }

            }

            return isSuccess;

        }

        private static string Get(string host, string key)

        {

            using (RedisClient redisClient = new RedisClient(host))

            {

                return redisClient.Get<string>(key);

            }

        }



    }
}

