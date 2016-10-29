﻿//using System;
//using AutoMapper;
//using Microsoft.EntityFrameworkCore;
//using NUnit.Framework;
//using Weapsy.Domain.Data.SqlServer.Repositories;
//using Weapsy.Domain.Themes;
//using Weapsy.Tests.Factories;
//using ThemeDbEntity = Weapsy.Domain.Data.SqlServer.Entities.Theme;

//namespace Weapsy.Domain.Data.SqlServer.Tests.Repositories
//{
//    [TestFixture]
//    public class ThemeRepositoryTests
//    {
//        private DbContextOptions<WeapsyDbContext> _contextOptions;
//        private Guid _themeId1;
//        private Guid _themeId2;

//        [SetUp]
//        public void SetUp()
//        {
//            _contextOptions = Shared.CreateContextOptions();

//            using (var context = new WeapsyDbContext(_contextOptions))
//            {
//                _themeId1 = Guid.NewGuid();
//                _themeId2 = Guid.NewGuid();

//                context.Set<ThemeDbEntity>().AddRange
//                (
//                    new ThemeDbEntity
//                    {
//                        Id = _themeId1,
//                        Name = "Name 1",
//                        Description = "Description 1",
//                        Folder = "Folder 1",
//                        Status = ThemeStatus.Active
//                    },
//                    new ThemeDbEntity
//                    {
//                        Id = _themeId2,
//                        Name = "Name 2",
//                        Description = "Description 2",
//                        Folder = "Folder 2",
//                        Status = ThemeStatus.Active
//                    },
//                    new ThemeDbEntity
//                    {
//                        Status = ThemeStatus.Deleted
//                    }
//                );

//                context.SaveChanges();
//            }
//        }

//        [Test]
//        public void Should_return_theme_by_id()
//        {
//            var actual = _sut.GetById(_themeId1);
//            Assert.NotNull(actual);
//        }

//        [Test]
//        public void Should_return_theme_by_name()
//        {
//            var actual = _sut.GetByName("Name 1");
//            Assert.NotNull(actual);
//        }

//        [Test]
//        public void Should_return_theme_by_folder()
//        {
//            var actual = _sut.GetByFolder("Folder 1");
//            Assert.NotNull(actual);
//        }

//        [Test]
//        public void Should_return_all_themes()
//        {
//            var actual = _sut.GetAll();
//            Assert.AreEqual(2, actual.Count);
//        }

//        [Test]
//        [Ignore("No idea why count is 10 instead of 2")]
//        public void Should_return_themes_count()
//        {
//            var actual = _sut.GetThemesCount();
//            Assert.AreEqual(2, actual);
//        }

//        [Test]
//        public void Should_save_new_theme()
//        {
//            var newTheme = ThemeFactory.Theme(Guid.NewGuid(), "Name 3", "Description 3", "Folder 3");
//            var newThemeDbEntity = new ThemeDbEntity
//            {
//                Id = newTheme.Id,
//                Name = newTheme.Name,
//                Description = newTheme.Description,
//                Folder = newTheme.Folder
//            };

//            _sut.Create(newTheme);

//            var actual = _sut.GetById(newTheme.Id);

//            Assert.NotNull(actual);
//        }

//        [Test]
//        public void Should_update_theme()
//        {
//            var newThemeDescription = "New Description 1";

//            var themeToUpdate = ThemeFactory.Theme(_themeId1, "Name 1", newThemeDescription, "Folder 1");

//            _sut.Update(themeToUpdate);

//            var updatedTheme = _sut.GetById(_themeId1);

//            Assert.AreEqual(newThemeDescription, updatedTheme.Description);
//        }
//    }
//}