using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.Common
{
	public static class IPAddressFinder
	{
		public static string GetHostName()
		{
			string ip = "";

			var hostName = Dns.GetHostName();
			var address = Dns.GetHostAddresses(hostName);

			//Eğer Ipv4 adresine ulaşmak istiyorsanız bunun için InterNetwork sabit değerine ihtiyacınız bulunmaktadır.
			foreach (var item in address)
			{
				if (item.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
				{
					ip = item.ToString();
				}
			}



			return ip;
		}
	}
}
