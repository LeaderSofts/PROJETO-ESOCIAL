using Pst.Business.Helpers;
using Pst.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Pst.Business.Repositories
{
    public partial class GrupoUsuarioRepository : EFRepository<GrupoUsuario>
    {
        public GrupoUsuarioRepository() : base("dbEF") { }

        public void Salvar(GrupoUsuario entity)
        {
            try
            {
                if (!this.IsValidEntity(entity))
                {
                    throw new PstException(string.Format("{0}{1}{2}", MessagesPst.ErpDataValidation, Environment.NewLine, string.Join(Environment.NewLine, this.GetErrorsEntity())));
                }
                else
                {                    
                    if (entity.id_grupo_usuario > 0)
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

        public void Excluir(int? id_empresa, int[] values)
        {
            try
            {
                Array.ForEach<int>(values, delegate(int value)
                {
                    this.DeleteNotSaveChanges(c => c.id_empresa == id_empresa && c.id_grupo_usuario == value);
                });

                this.SaveChanges();
            }
            catch (Exception ex)
            {
                LogPst.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }

        public GrupoUsuario Obter(int id_grupo_usuario, int? id_empresa)
        {
            try
            {
                return this.FindSingleBy(f => f.id_grupo_usuario == id_grupo_usuario && f.id_empresa == id_empresa);
            }
            catch (Exception ex)
            {
                LogPst.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }

        public List<GrupoUsuario> Listar(int? id_empresa, Pst.Business.Models.Usuario.TypeUser tipo_usuario)
        {
            try
            {
                if(tipo_usuario == Usuario.TypeUser.USER)                    
                    return this.FindAllBy(f => f.id_empresa == id_empresa).ToList();                   
                else
                    return this.FindAllBy(f => f.id_empresa == id_empresa || f.id_empresa == null).ToList();   
            }
            catch (Exception ex)
            {
                LogPst.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }

        public Pagination<GrupoUsuario> Listar(int? id_empresa, Pst.Business.Models.Usuario.TypeUser tipo_usuario, string ocorrencia, int? page, int? limit)
        {
            try
            {
                Expression<Func<GrupoUsuario, bool>> predicate;

                if (string.IsNullOrEmpty(ocorrencia))
                {
                    if (tipo_usuario == Usuario.TypeUser.USER) 
                        predicate = w => w.id_empresa == id_empresa;
                    else
                        predicate = w => w.id_empresa == id_empresa || w.id_empresa == null;
                }
                else
                {
                    if (tipo_usuario == Usuario.TypeUser.USER)    
                        predicate = f => f.id_empresa == id_empresa && f.descricao.Contains(ocorrencia);
                    else
                        predicate = f => (f.id_empresa == id_empresa || f.id_empresa == null) && f.descricao.Contains(ocorrencia);                        
                }

                return this.FindAllBy(predicate, o => o.descricao, page, limit);
            }
            catch (Exception ex)
            {
                LogPst.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }

    }
}