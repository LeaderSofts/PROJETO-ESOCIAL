using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Portal.Business.Utils
{
    public class LogUtil
    {
        public static void Gravar(Exception exception)
        {
            Gravar(exception, false);
        }

        public static void Gravar(Exception exception, bool isThrow)
        {
            string error = _GetExceptionError(exception);
         
            try
            {
                string dir = string.Format(@"{0}/Logs/{1:yyyyMM}", Environment.CurrentDirectory, DateTime.Now);
                string file = string.Format(@"{0}/log_{1}.log", dir, exception.GetType().Name).ToLower();

                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                File.AppendAllText(file, string.Format("{0:dd/MM/yyyy HH:mm:ss} - {1}{2}", DateTime.Now, error, Environment.NewLine));           
            }
            catch(Exception ex) 
            {
                error = string.Format("[ {0} | {1} | {2} ] | {3}", ex.Source, ex.Message, ex.StackTrace, error);
            }
            finally
            {
                if(isThrow)
                {
                    throw new Exception(string.Format("ATENÇÃO: Ocorreu um erro durante a execução! - Error: {0}", error));
                }
            }
        }

        private static string _GetExceptionError(Exception ex)
        {
            string error = string.Empty;

            if (ex != null)
            {
                error = string.Format("[ APP: {0} | ERRO: {1} | RASTREAMENTO: {2} | DESTINO: {3}]", ex.Source, ex.Message, ex.StackTrace, ex.TargetSite);
                string error_aux = _GetExceptionError(ex.InnerException);

                if (!string.IsNullOrEmpty(error_aux))                
                    error += string.Format(" | ERRO AUX: {0}", error_aux);                
            }

            return error;
        }
    }
}