using System;

namespace ActiveSitemap.CustomInfrastructure {

	public class ConfigurationException : ApplicationException {
		public ConfigurationException() { }

		public ConfigurationException(string message) : base(message) { }

	}

}
