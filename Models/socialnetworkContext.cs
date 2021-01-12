using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Vkontakte.Models
{
    public class socialnetworkContext : DbContext
    {
        public DbSet<Пользователь> Пользователь { get; set; }
        public DbSet<Беседа> Беседа { get; set; }
        public DbSet<Участник> Участник { get; set; }
        public DbSet<Блог> Блог { get; set; }
        public DbSet<Дествие> Дествие { get; set; }
        public DbSet<Дружба> Дружба { get; set; }
        public DbSet<Запись> Запись { get; set; }
        public DbSet<Коментарий> Коментарий { get; set; }
        public DbSet<Подписчик> Подписчик { get; set; }
        public DbSet<Сообщения> Сообщения { get; set; }
        public DbSet<Статус_дружбы> Статус_Дружбы { get; set; }
        public DbSet<Тематика> Тематика { get; set; }
        public DbSet<Тип_блога> ТипыБлогов { get; set; }
        public DbSet<Тип_действия> ТипыДействий { get; set; }
        public DbSet<UsersWithCommon> users { get; set; }
        public DbSet<TrendPosts> trends { get; set; }
        public DbSet<Аватарка> Аватарка { get; set; }
        public DbSet<Приложение> Приложение { get; set; }
        public DbSet<Данные> Данные { get; set; }
        public socialnetworkContext(DbContextOptions<socialnetworkContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Статус_дружбы>().ToTable("Статус дружбы");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Тип_блога>().ToTable("Тип блога");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Тип_действия>().ToTable("Тип действия");
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UsersWithCommon>().ToView("View1");
            modelBuilder.Entity<TrendPosts>().ToView("SELECTTRENDS");
            modelBuilder.Entity<Пользователь>().Property(p => p.ID).HasColumnName("ID Пользователя");
            modelBuilder.Entity<Пользователь>().Property(p => p.Дата_рождения).HasColumnName("Дата рождения");
            modelBuilder.Entity<Данные>().Property(p => p.ID).HasColumnName("ID Данных");
            modelBuilder.Entity<Приложение>().Property(p => p.ID_Data).HasColumnName("ID Данных");
            modelBuilder.Entity<Приложение>().Property(p => p.ID_Записи).HasColumnName("ID Записи");
            modelBuilder.Entity<Аватарка>().Property(p => p.ID_Пользователя).HasColumnName("ID Пользователя");
            modelBuilder.Entity<Аватарка>().Property(p => p.ID_Data).HasColumnName("ID Картинки");
            modelBuilder.Entity<Аватарка>().Property(p => p.Дата_изменения).HasColumnName("Дата изменения");
            modelBuilder.Entity<Беседа>().Property(p => p.ID_Беседы).HasColumnName("ID Беседы");
            modelBuilder.Entity<Беседа>().Property(p => p.Название_беседы).HasColumnName("Название беседы");
            modelBuilder.Entity<Беседа>().Property(p => p.Дата_создания).HasColumnName("Дата создания");
            modelBuilder.Entity<Беседа>().Property(p => p.Описание_беседы).HasColumnName("Описание беседы");
            modelBuilder.Entity<Беседа>().Property(p => p.Дата_создания).HasColumnName("Дата создания");
            modelBuilder.Entity<Участник>().Property(p => p.Дата_последнего_просмотра).HasColumnName("Дата последнего просмотра");
            modelBuilder.Entity<Участник>().Property(p => p.Дата_добавления).HasColumnName("Дата добавления");
            modelBuilder.Entity<Участник>().Property(p => p.ID_беседы).HasColumnName("ID беседы");
            modelBuilder.Entity<Участник>().Property(p => p.ID_Пользователя).HasColumnName("ID Пользователя");
            modelBuilder.Entity<Блог>().Property(p => p.ID_Блога).HasColumnName("ID Блога");
            modelBuilder.Entity<Блог>().Property(p => p.ID_Создателя).HasColumnName("ID Создателя");
            modelBuilder.Entity<Блог>().Property(p => p.Дата_создания).HasColumnName("Дата создания");
            modelBuilder.Entity<Блог>().Property(p => p.Код_типа).HasColumnName("Код типа");
            modelBuilder.Entity<Блог>().Property(p => p.Код_типа_тематики).HasColumnName("Код тематики");
            modelBuilder.Entity<Дествие>().Property(p => p.ID_Записи).HasColumnName("ID Записи");
            modelBuilder.Entity<Дествие>().Property(p => p.ID_Пользователя).HasColumnName("ID Пользователя");
            modelBuilder.Entity<Дествие>().Property(p => p.Дата_действия).HasColumnName("Дата действия");
            modelBuilder.Entity<Дружба>().Property(p => p.ID_Друга).HasColumnName("ID Друга");
            modelBuilder.Entity<Дружба>().Property(p => p.ID_Пользователя).HasColumnName("ID Пользователя");
            modelBuilder.Entity<Дружба>().Property(p => p.Дата_изиенения_статуса).HasColumnName("Дата изменения статуса");
            modelBuilder.Entity<Дружба>().Property(p => p.Код_статуса).HasColumnName("Код статуса");
            modelBuilder.Entity<Запись>().Property(p => p.ID_Блога).HasColumnName("ID Блога");
            modelBuilder.Entity<Запись>().Property(p => p.ID_Записи).HasColumnName("ID Записи");
            modelBuilder.Entity<Запись>().Property(p => p.Дата_публикации).HasColumnName("Дата публикации");
            modelBuilder.Entity<Коментарий>().Property(p => p.ID_Записи).HasColumnName("ID Записи");
            modelBuilder.Entity<Коментарий>().Property(p => p.ID_коментария).HasColumnName("ID коментария");
            modelBuilder.Entity<Коментарий>().Property(p => p.ID_Пользователя).HasColumnName("ID Пользователя");
            modelBuilder.Entity<Коментарий>().Property(p => p.Текст_коментария).HasColumnName("Текст коментария");
            modelBuilder.Entity<Подписчик>().Property(p => p.ID_Блога).HasColumnName("ID Блога");
            modelBuilder.Entity<Подписчик>().Property(p => p.ID_Пользователя).HasColumnName("ID Пользователя");
            modelBuilder.Entity<Сообщения>().Property(p => p.ID_беседы).HasColumnName("ID беседы");
            modelBuilder.Entity<Сообщения>().Property(p => p.ID_Пользователя).HasColumnName("ID Пользователя");
            modelBuilder.Entity<Сообщения>().Property(p => p.ID_Сообщения).HasColumnName("ID Сообщения");
            modelBuilder.Entity<Сообщения>().Property(p => p.Дата_отправки).HasColumnName("Дата отправки");
            modelBuilder.Entity<Сообщения>().Property(p => p.Текст_сообщения).HasColumnName("Текст сообщения");
            modelBuilder.Entity<Статус_дружбы>().Property(p => p.Код_статуса).HasColumnName("Код статуса");
            modelBuilder.Entity<Тематика>().Property(p => p.Код_типа_тематики).HasColumnName("Код типа тематики");
            modelBuilder.Entity<Тип_блога>().Property(p => p.Код_типа_блога).HasColumnName("Код типа блога");
            modelBuilder.Entity<Тип_действия>().Property(p => p.Код_действия).HasColumnName("Код действия");

            modelBuilder.Entity<Участник>().HasKey(p => new { p.ID_беседы, p.ID_Пользователя });
            modelBuilder.Entity<Дествие>().HasKey(p => new { p.ID_Записи, p.ID_Пользователя, p.Код });
            modelBuilder.Entity<Дружба>().HasKey(p => new { p.ID_Пользователя, p.ID_Друга, p.Дата_изиенения_статуса });
            modelBuilder.Entity<Коментарий>().HasKey(p => new { p.ID_Пользователя, p.ID_коментария, p.ID_Записи });
            modelBuilder.Entity<Подписчик>().HasKey(p => new { p.ID_Блога, p.ID_Пользователя });
            modelBuilder.Entity<Аватарка>().HasKey(p => new { p.ID_Data, p.ID_Пользователя });
            modelBuilder.Entity<Приложение>().HasKey(p => new { p.ID_Data, p.ID_Записи });

            modelBuilder.Entity<Дружба>().HasOne(p => p.Пользователь).WithMany(p => p.Дружбы).HasForeignKey(p => p.ID_Пользователя);
            modelBuilder.Entity<Дружба>().HasOne(P => P.Друг).WithMany(p => p.ИменияДружб).HasForeignKey(p => p.ID_Друга);
            modelBuilder.Entity<Дружба>().HasOne(p => p.Статус_Дружбы).WithMany(p => p.Дружбы).HasForeignKey(p => p.Код_статуса);
            modelBuilder.Entity<Участник>().HasOne(p => p.Пользователь).WithMany(p => p.Участия).HasForeignKey(p => p.ID_Пользователя);
            modelBuilder.Entity<Участник>().HasOne(p => p.Беседа).WithMany(p => p.Участники).HasForeignKey(p => p.ID_беседы);
            modelBuilder.Entity<Сообщения>().HasOne(p => p.Участник).WithMany(p => p.Сообщения).HasForeignKey(p => new { p.ID_беседы, p.ID_Пользователя });
            modelBuilder.Entity<Коментарий>().HasOne(p => p.Пользователь).WithMany(p => p.Коментарии).HasForeignKey(p => p.ID_Пользователя);
            modelBuilder.Entity<Коментарий>().HasOne(p => p.Запись).WithMany(p => p.Коментарии).HasForeignKey(p => p.ID_Записи);
            modelBuilder.Entity<Дествие>().HasOne(p => p.Пользователь).WithMany(p => p.Действия).HasForeignKey(p => p.ID_Пользователя);
            modelBuilder.Entity<Дествие>().HasOne(p => p.Запись).WithMany(p => p.Действия).HasForeignKey(p => p.ID_Записи);
            modelBuilder.Entity<Дествие>().HasOne(p => p.Тип_Действия).WithMany(p => p.Действия).HasForeignKey(p => p.Код);
            modelBuilder.Entity<Подписчик>().HasOne(p => p.Блог).WithMany(p => p.Подписчики).HasForeignKey(p => p.ID_Блога);
            modelBuilder.Entity<Подписчик>().HasOne(p => p.Пользователь).WithMany(p => p.Подписки).HasForeignKey(p => p.ID_Пользователя);
            modelBuilder.Entity<Блог>().HasOne(p => p.Пользователь).WithMany(p => p.Блоги).HasForeignKey(p => p.ID_Создателя);
            modelBuilder.Entity<Блог>().HasOne(p => p.Тематика).WithMany(p => p.Блоги).HasForeignKey(p => p.Код_типа_тематики);
            modelBuilder.Entity<Блог>().HasOne(p => p.Тип_Блога).WithMany(p => p.Блоги).HasForeignKey(p => p.Код_типа);
            modelBuilder.Entity<Запись>().HasOne(p => p.Блог).WithMany(p => p.Записи).HasForeignKey(p => p.ID_Блога);
            modelBuilder.Entity<Аватарка>().HasOne(p => p.Пользователь).WithMany(p => p.Аватарки).HasForeignKey(p => p.ID_Пользователя);
            modelBuilder.Entity<Аватарка>().HasOne(p => p.Данные).WithMany(p => p.Аватарки).HasForeignKey(p => p.ID_Data);
            modelBuilder.Entity<Приложение>().HasOne(p => p.Запись).WithMany(p => p.Приложения).HasForeignKey(p => p.ID_Записи);
            modelBuilder.Entity<Приложение>().HasOne(p => p.Данные).WithMany(p => p.Приложения).HasForeignKey(p => p.ID_Data);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            string configuring = "Data Source=localhost;Initial Catalog=socialnetwork;Integrated Security=True;";
            optionsBuilder.UseSqlServer(configuring);
        }
    }
}
