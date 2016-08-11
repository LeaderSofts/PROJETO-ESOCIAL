using Pst.Business.Helpers;
using Pst.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pst.Business.Repositories
{
    public partial class PermissaoGrupoUsuarioRepository : EFRepository<PermissaoGrupoUsuario>
    {
        public PermissaoGrupoUsuarioRepository() : base("dbEF") { }

        public void Salvar(PermissaoGrupoUsuario entity, int modulo_pai)
        {
            try
            {
                if (!this.IsValidEntity(entity))
                    throw new PstException(string.Format("{0}{1}{2}", MessagesPst.ErpDataValidation, Environment.NewLine, string.Join(Environment.NewLine, this.GetErrorsEntity())));
                else
                {
                    this.SaveNotSaveChanges(entity);

                    if (entity.id_modulo != modulo_pai)
                    {
                        if (this.Session.Where(w => w.id_modulo == modulo_pai && w.id_grupo_usuario == entity.id_grupo_usuario).Count() == 0)
                        {
                            this.SaveNotSaveChanges(new PermissaoGrupoUsuario()
                            {
                                id_grupo_usuario = entity.id_grupo_usuario,
                                id_modulo = modulo_pai
                            });
                        }
                    }

                    this.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                LogPst.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }

        public void Excluir(int modulo_pai, int id_grupo_usuario, params int[] values)
        {
            try
            {
                Array.ForEach<int>(values, delegate(int value)
                {
                    this.DeleteNotSaveChanges(c => c.id_permissao_grupo_usuario == value);            
                });

                this.SaveChanges();

                if (!values.Contains(modulo_pai))
                {
                    var listPermitidos = ListarPermitidos(id_grupo_usuario, modulo_pai);

                    if (listPermitidos.Count == 0)
                    {
                        this.DeleteNotSaveChanges(c => c.id_modulo == modulo_pai && c.id_grupo_usuario == id_grupo_usuario);
                        this.SaveChanges();
                    }
                }

            }
            catch (Exception ex)
            {
                LogPst.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }

        public PermissaoGrupoUsuario Obter(int id_permissao_grupo_usuario)
        {
            try
            {
                return this.FindSingleBy(f => f.id_permissao_grupo_usuario == id_permissao_grupo_usuario);
            }
            catch (Exception ex)
            {
                LogPst.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }

        public List<PermissaoGrupoUsuarioAux> ListarPermitidos(int id_grupo_usuario, int id_modulo)
        {
            try
            {
                string qry = @"SELECT 
                                    pgu.id_permissao_grupo_usuario,
                                    pgu.id_modulo,
                                    pgu.id_grupo_usuario,
                                    m.descricao descricao_modulo
                                FROM
                                    erp_modulo m
                                    INNER JOIN erp_permissao_grupo_usuario pgu ON pgu.id_modulo = m.id_modulo 
                                WHERE
                                    pgu.id_grupo_usuario = {0}
	                                AND (m.id_modulo = {1} OR m.id_modulo_pai = {1})
                                ORDER BY
                                    m.id_modulo_pai ASC, m.indice ASC";

                return this.Database.SqlQuery<PermissaoGrupoUsuarioAux>(qry, id_grupo_usuario, id_modulo).ToList();
            }
            catch (Exception ex)
            {
                LogPst.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }

        public List<PermissaoGrupoUsuarioAux> ListarNaoPermitidos(int id_grupo_usuario, int id_modulo)
        {
            try
            {
                string qry = @"SELECT 
                                    0 id_permissao_grupo_usuario,
                                    m.id_modulo,
                                    {1} id_grupo_usuario,
                                    descricao descricao_modulo
                                FROM
                                    erp_modulo m
                                WHERE
	                                (m.id_modulo = {0} OR m.id_modulo_pai = {0})
	                                AND m.id_modulo NOT IN (SELECT id_modulo FROM erp_permissao_grupo_usuario WHERE id_grupo_usuario = {1} AND id_modulo = m.id_modulo)
                                ORDER BY
                                    m.id_modulo_pai ASC, m.indice ASC";

                return this.Database.SqlQuery<PermissaoGrupoUsuarioAux>(qry, id_modulo, id_grupo_usuario).ToList();
            }
            catch (Exception ex)
            {
                LogPst.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }
    }
}