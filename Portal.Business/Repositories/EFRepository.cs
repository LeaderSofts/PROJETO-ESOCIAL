using Portal.Business.Interfaces;
using Portal.Business.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace Portal.Business.Repositories
{
    public class EFRepository<T> : DbContext, IRepository<T> where T : class
    {
        public DbSet<T> Session{ get; set; }

        public EFRepository(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {                       
            //this.Database.Connection.ConnectionString = ConfigurationManager.ConnectionStrings[nameOrConnectionString].ConnectionString;

            if (Session == null) Session = this.Set<T>();
        }

        public virtual T FindSingleBy(Expression<Func<T, bool>> predicate)
        {
            if (predicate != null)
            {
                return this.Set<T>().Where(predicate).SingleOrDefault();                
            }
            else
            {
                throw new ArgumentNullException("Predicate value must be passed to FindSingle.");
            }
        }

        public virtual IQueryable<T> FindAllBy(Expression<Func<T, bool>> predicate)
        {
            if (predicate != null)
            {
                return Session.Where(predicate);
            }
            else
            {
                throw new ArgumentNullException("Predicate value must be passed to FindAllBy.");
            }
        }

        public virtual IEnumerable<T> FindAllBy()
        {
            return Session.ToList();
        }


        public virtual IQueryable<T> FindAllOrderBy(Expression<Func<T, object>> keySelector)
        {
            if (keySelector != null)
            {
                return Session.OrderBy(keySelector);
            }
            else
            {
                throw new ArgumentNullException("KeySelector value must be passed to FindAllOrderBy.");
            }
        }

        public virtual int Save(T entity)
        {
            if (entity != null)
            {
                Session.Add(entity);
                return this.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Entity value must be passed to Save.");
            }
        }


        public virtual void SaveNotSaveChanges(T entity)
        {
            if (entity != null)
            {
                Session.Add(entity);
            }
            else
            {
                throw new ArgumentException("Entity value must be passed to Save.");
            }
        }

        public virtual int Update(T entity)
        {
            if (entity != null)
            {
                Session.Attach(entity);
                Entry(entity).State = EntityState.Modified;
                return this.SaveChanges();
            }
            else
            {   
                throw new ArgumentException("Entity value must be passed to Update.");            
            }
        }

        List<string> _errorsEntity = new List<string>();

        public List<string> GetErrorsEntity()
        {
            return (_errorsEntity != null ? _errorsEntity : new List<string>());
        }

        public virtual bool IsValidEntity(T entity)
        {

            var validationResult = Entry(entity).GetValidationResult();
    
            if(!validationResult.IsValid)
            {
                _errorsEntity = new List<string>();

                _errorsEntity.Add(string.Format("O objeto {0} contém alguns erros, verifique:", validationResult.Entry.Entity));

                foreach (var error in validationResult.ValidationErrors)
                {
                    _errorsEntity.Add(string.Format("- {0}", error.ErrorMessage));                    
                }

                return false;
            }

            return true;
        }

        public virtual int Delete(T entity)
        {                            
            if (entity != null)                
            {            
                Session.Remove(entity);            
                return this.SaveChanges();                
            }                
            else                
            {                    
                throw new ArgumentException("Entity value must be passed to Update.");                
            }
        }

        public virtual int Delete(Expression<Func<T, bool>> predicate)
        {
            if (predicate != null)
            {                
                this.Set<T>().Where(predicate).ToList().ForEach(del => this.Set<T>().Remove(del));
                return this.SaveChanges();     
            }
            else
            {
                throw new ArgumentNullException("Predicate value must be passed to Delete.");
            }
        }

        public virtual void DeleteNotSaveChanges(Expression<Func<T, bool>> predicate)
        {
            if (predicate != null)
            {
                this.Set<T>().Where(predicate).ToList().ForEach(del => this.Set<T>().Remove(del));                
            }
            else
            {
                throw new ArgumentNullException("Predicate value must be passed to Delete.");
            }
        }


        public virtual long GetIdentity(string columnName)
        {
            return GetIdentity(typeof(T).Name, columnName);
        }

        public virtual long GetIdentity(string tableName, string columnName)
        { 
            long last_id = 0;
            var cmd = this.Database.Connection.CreateCommand();

            try
            {
                string sql = string.Format(@"DECLARE @return_value int
                                                    EXEC	@return_value = [dbo].[GetIdentity]
                                                    @tablename = N'{0}',
                                                    @columnname = N'{1}'
                                                    SELECT @return_value AS 'Return Value'", tableName, columnName);
                cmd.CommandText = sql;
                cmd.CommandType = System.Data.CommandType.Text;

                if (cmd.Connection.State == System.Data.ConnectionState.Closed)
                    cmd.Connection.Open();

                last_id = Convert.ToInt64(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }


            return last_id;
        }        

    }
}