using System.Collections.Generic;

namespace Campaigns.App.Utils
{
    public class ParameterUtil
    {
        public static object[] FixParameterTypes(object[] command)
        {
            var parameters = new List<object>();

            for (int i = 1; i < command.Length; i++)
            {
                string param = command[i].ToString();

                if (int.TryParse(param, out int value))
                    parameters.Add(value);
                else
                    parameters.Add(param);
            }

            return parameters.ToArray();
        }
    }
}
