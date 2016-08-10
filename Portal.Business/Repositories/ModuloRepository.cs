using Pst.Business.Helpers;
using Pst.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pst.Business.Repositories
{
    public partial class ModuloRepository :  EFRepository<Modulo>
    {
        public ModuloRepository() : base("dbEF") { }

        public void SaveModule(Modulo entity)
        {
            try
            {
                if (!this.IsValidEntity(entity))
                {
                    throw new PstException(string.Format("{0}{1}{2}", MessagesPst.ErpDataValidation, Environment.NewLine, string.Join(Environment.NewLine, this.GetErrorsEntity())));
                }
                else
                {
                    if (entity.id_modulo > 0)
                        this.Update(entity);
                    else
                        this.Save(entity);
                }

            }
            catch (Exception ex)
            {
                LogPst.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int[] values)
        {
            try
            {
                Array.ForEach<int>(values, delegate(int value)
                {
                    this.DeleteNotSaveChanges(c => c.id_modulo == value);
                });

                this.SaveChanges();
            }
            catch (Exception ex)
            {
                LogPst.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }

        public Modulo Get(int id_modulo)
        {
            try
            {
                return this.FindSingleBy(f => f.id_modulo == id_modulo);

            }
            catch (Exception ex)
            {
                LogPst.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }

        public List<Modulo> GetAllByUser(int id_usuario)
        {
            try
            {
                string qry = @"select m.* from erp_modulo m 
                               inner join erp_permissao_grupo_usuario pgu on pgu.id_modulo = m.id_modulo
                               inner join erp_usuario u on u.id_grupo_usuario = pgu.id_grupo_usuario
                               where u.id_usuario = {0}
                               order by id_modulo_pai asc, indice asc, descricao asc";

                return this.Database.SqlQuery<Modulo>(qry, id_usuario).ToList();
            }
            catch (Exception ex)
            {
                LogPst.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }

        public List<Modulo> GetAll()
        {
            try
            {
                return this.FindAllBy().OrderBy(o => o.id_modulo_pai).ToList();
            }
            catch (Exception ex)
            {
                LogPst.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }

        public Pagination<Modulo> GetAll(string ocorrencia, int? page, int? limit)
        {
            try
            {
                if (string.IsNullOrEmpty(ocorrencia))
                {
                    return this.FindAllBy(o => o.descricao, page, limit);
                }
                else
                {
                    int codigo;
                    int.TryParse(ocorrencia, out codigo);

                    return this.FindAllBy(f => f.descricao.Contains(ocorrencia) ||
                                          f.url.Contains(ocorrencia) ||
                                          f.id_modulo == codigo ||
                                          f.id_modulo_pai == codigo, o => o.descricao, page, limit);
                }
            }
            catch (Exception ex)
            {
                LogPst.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }
    }
}