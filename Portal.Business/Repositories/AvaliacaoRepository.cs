using Portal.Business.Helpers;
using Portal.Business.Models;
using Portal.Business.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Portal.Business.Repositories
{
    public partial class AvaliacaoRepository : EFRepository<Avaliacao>
    {
        public AvaliacaoRepository() : base("dbEF") { }

        public void Salvar(Avaliacao entity)
        {
            try
            {
                entity.dh_cad_avaliacao = DateTime.Now;

                if (!this.IsValidEntity(entity))
                    throw new PortalException(string.Format("{0}{1}{2}", MessagesPortal.PortalDataValidation, Environment.NewLine, string.Join(Environment.NewLine, this.GetErrorsEntity())));
                else
                {
                    var efAnuncio = EFUnitOfWork.GetRepository<AnuncioRepository>();
                    var anuncio = efAnuncio.Obter(entity.id_anuncio);
                    anuncio.status_anuncio = Anuncio.TypeStatusAnuncio.Finalizado;
                    efAnuncio.Update(anuncio);
                    this.Save(entity);
                }
            }                              
            catch (Exception ex)
            {
                LogUtil.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }
    }
}