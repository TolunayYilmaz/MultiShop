﻿namespace MultiShop.Cargo.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T :class
    {
        void TInsert(T entity);
        void TDelete(int id);
        void TUpdate(T entity);
        T TGetById(int id);
        List<T> TGetAll();

    }
}
