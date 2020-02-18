using System.Collections.Generic;

namespace MailSender.lib.Services.Iterfaces2
{

    /// <summary>
    /// Хранилище объектов
    /// </summary>
    /// <typeparam name="T">тип хранимого объекта</typeparam>
    public interface IDataStore<T>
    {
        /// <summary>
        /// Получить все объекты
        /// </summary>
        /// <returns>Перечисление объектов</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Получить объект по идентификатору
        /// </summary>
        /// <param name="id"> Числовой идентификатор объекта в хранилище</param>
        /// <returns>Найденный объект или <see langword="null"/></returns>
        T GetById(int id);

        /// <summary>
        /// Создать (добавить) объект в хранилище
        /// </summary>
        /// <param name="item">создаваемый (добавляемый в хранилище) объект</param>
        /// <returns>Идентификатор, присвоенный хранилищем объекту</returns>
        int Create(T item);

        /// <summary>
        /// Отредактировать объект в хранилище
        /// </summary>
        /// <param name="id">Идентификатор объекта, который требуется отредактировать</param>
        /// <param name="item">Модель данных, которые надо передать в редактируемый объект</param>
        void Edit(int id, T item);

        /// <summary>
        /// Удалить объект из хранилища по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор удаляемого объекта</param>
        /// <returns> удаленный из хранеилища объект, либо<see langword="null"/> если объекта в хранилище не было</returns>
        T Remove(int id);

        /// <summary>
        /// Сохранить выполненные изменения
        /// </summary>
        void SaveChanges();
    }
}
