using Intellectus_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Intellectus_mvc
{
    public class BaseService<T> : IService<T> where T : BaseModel
    {
        private IValidationDictionary validationDictionary;
        private UnitOfWork unitOfWork;
        public BaseService(UnitOfWork _unitOfWork, IValidationDictionary _validationDictionary)
        {
            this.unitOfWork = _unitOfWork;
            this.validationDictionary = _validationDictionary;
        }
        public virtual List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return unitOfWork.GetRepository<T>().GetAll();
        }

        public virtual void Create(T entity)
        {
            unitOfWork.GetRepository<T>().Insert(entity);
            unitOfWork.Save();
            unitOfWork.Dispose();
        }

        public virtual void Update(T entity)
        {
            unitOfWork.GetRepository<T>().Update(entity);
            unitOfWork.Save();
            unitOfWork.Dispose();
        }

        public virtual void Delete(T entity)
        {
            unitOfWork.GetRepository<T>().Delete(entity);
            unitOfWork.Save();
            unitOfWork.Dispose();
        }
        public virtual T Get(int id)
        {
            return unitOfWork.GetRepository<T>().GetById(id);
        }

        public bool Save(T item)
        {
            unitOfWork.GetRepository<T>().Save(item);
            return unitOfWork.Save() > 0;

        }
    }
}
