using ONE_Service.Util;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONE_Service.Servicios
{
    public class ProcesoExtractFTP : IJob
    {

        public Semaforo semaforo = Semaforo.getInstance("ProcesoExtractFTP");

        public void Execute(IJobExecutionContext context)
        {

            if (semaforo.EstaProcesando == false)
            {
                semaforo.EstaProcesando = true;

                try
                {




                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (semaforo.EstaProcesando == true)
                    {
                        Semaforo.setInstance("ProcesoExtractFTP");
                        if (semaforo.CantidadArchivosConError > 0)

                            Semaforo.setInstance("ProcesoExtractFTP");
                    }
                }
            }

        }

    }
}
