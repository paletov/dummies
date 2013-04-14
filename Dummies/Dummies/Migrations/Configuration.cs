using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Dummies.Models.Contexts;
using System.Web.Security;
using WebMatrix.WebData;
using Dummies.Models.Repos;
using Dummies.Models;

namespace Dummies.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<DummiesContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
		}

		protected override void Seed(DummiesContext context)
		{
			WebSecurity.InitializeDatabaseConnection("DefaultConnection",
				"UserProfile", "UserId", "UserName", autoCreateTables: true);

			SeedRolesAndUsers();
			SeedSemesters();
			SeedBachelorProgrammes();
			SeedCourses();
		}

		private void SeedRolesAndUsers()
		{
			var roles = (SimpleRoleProvider)Roles.Provider;
			var membership = (SimpleMembershipProvider)Membership.Provider;

			if (!roles.RoleExists("Student"))
			{
				roles.CreateRole("Student");

				//if (membership.GetUser("Rumen", false) == null)
				//{
				//    membership.CreateUserAndAccount("Rumen", "Rumen1234");

				//    using (StudentProfileRepository repository = new StudentProfileRepository())
				//    {
				//        StudentProfile profile = new StudentProfile()
				//        {
				//            FacultyNumber = 80555
				//        }
				//    }
				//}
			}
			if (!roles.RoleExists("Bussines"))
			{
				roles.CreateRole("Bussines");
			}
			//if (membership.GetUser("sallen", false) == null)
			//{
			//    membership.CreateUserAndAccount("sallen", "imalittleteapot");
			//}
			//if (!roles.GetRolesForUser("sallen").Contains("Admin"))
			//{
			//    roles.AddUsersToRoles(new[] { "sallen" }, new[] { "admin" });
			//}
		}

		private void SeedSemesters()
		{
			using(SemesterRepository repository = new SemesterRepository())
			{
				repository.InsertOrUpdate(new Semester("summer", 2012, 2013));
				repository.InsertOrUpdate(new Semester("winter", 2012, 2013));
				repository.Save();
			}
		}

		private void SeedBachelorProgrammes()
		{
			using (BachelorProgrammeRepository repository = new BachelorProgrammeRepository())
			{
				repository.InsertOrUpdate(new BachelorProgramme("Информатика"));
				repository.InsertOrUpdate(new BachelorProgramme("Компютърни науки"));
				repository.InsertOrUpdate(new BachelorProgramme("Математика"));
				repository.InsertOrUpdate(new BachelorProgramme("Математика и информатика"));
				repository.InsertOrUpdate(new BachelorProgramme("Приложна математика"));
				repository.InsertOrUpdate(new BachelorProgramme("Информационни системи"));
				repository.InsertOrUpdate(new BachelorProgramme("Софтуерно инженерство"));
				repository.InsertOrUpdate(new BachelorProgramme("Статистика"));
				repository.InsertOrUpdate(new BachelorProgramme("Изборни Дисциплини"));
				repository.Save();
			}
		}

		public void SeedCourses()
		{
			using(CourseRepository repository = new CourseRepository())
			{
				repository.InsertOrUpdate(new Course("Динамични геометрични системи", "DID", 5.0, "1", 9, 0));
				repository.InsertOrUpdate(new Course("Компютърна евристика", "DID", 7.0, "1", 9, 0));
				repository.InsertOrUpdate(new Course("Математически методи в педагогическата диагностика", "DID", 5.0, "1", 9, 0));
				repository.InsertOrUpdate(new Course("Неравенства", "DID", 5.0, "1", 9, 0));
				repository.InsertOrUpdate(new Course("Педагогически функции на интерактивна бяла дъска", "DID", 5.0, "1", 9, 0));
				repository.InsertOrUpdate(new Course("СОТ (Съвременни образователни технологии)", "DID", 5.0, "1", 9, 0));
				repository.InsertOrUpdate(new Course("Съдържание и методика на извънкласната работа по математика", "DID", 5.0, "1", 9, 0));
				repository.InsertOrUpdate(new Course("Технолигиите в помощ на образователни проекти", "DID", 5.0, "1", 9, 0));
				repository.InsertOrUpdate(new Course("Учебна документация", "DID", 5.0, "1", 9, 0));
				repository.InsertOrUpdate(new Course("Устройство на компютърните системи", "OTHR", 2.0, "1", 9, 0));
				repository.InsertOrUpdate(new Course("Съвременна физика", "OTHR", 5.0, "1", 9, 0));
				repository.InsertOrUpdate(new Course("Философия на математиката", "OTHR", 2.0, "2", 9, 0));
				repository.InsertOrUpdate(new Course("Visual basic за приложения", "INF", 5.0, "1", 9, 0));
				repository.InsertOrUpdate(new Course("Бази от данни-практикум - спец ИС", "CSP", 2.5, "1", 9, 0));
				repository.InsertOrUpdate(new Course("Компютърни архитектури - практикум", "CSP", 2.5, "1", 9, 0));
				repository.InsertOrUpdate(new Course("Математическа текстообработка", "CSP", 5.0, "1", 9, 0));
				repository.InsertOrUpdate(new Course("Увод в програмирането - практикум", "CSP", 2.5, "1", 9, 0));
				repository.InsertOrUpdate(new Course("Числени методи - практикум - спец И, М, ПМ", "CSP", 2.5, "1", 9, 0));
				repository.InsertOrUpdate(new Course("Числени методи - практикум - спец Ст", "CSP", 2.5, "1", 9, 0));
				repository.InsertOrUpdate(new Course("Числени методи за диференциални уравнения - практикум", "CSP", 3.5, "1", 9, 0));
				repository.InsertOrUpdate(new Course("Дизайн и анализ на алгоритми - практикум - спец И и КН", "CSP", 3.5, "1", 9, 0));
				repository.InsertOrUpdate(new Course("Софтуерни технологии - практикум", "CSP", 2.5, "1", 9, 0));
				repository.InsertOrUpdate(new Course("Структури от данни и програмиране - практикум", "CSP", 2.5, "1", 9, 0));
				repository.InsertOrUpdate(new Course("Бази от данни-практикум - спец И, КН", "CSP", 5.0, "1", 9, 0));
				repository.InsertOrUpdate(new Course("Обектно-ориентирано програмиране - практикум - спец И", "CSP", 2.5, "1", 9, 0));
				repository.InsertOrUpdate(new Course("Обектно-ориентирано програмиране - практикум - спец КН", "CSP", 2.5, "1", 9, 0));
				repository.InsertOrUpdate(new Course("Обектно-ориентирано програмиране - практикум - спец ИС", "CSP", 2.5, "1", 9, 0));
				repository.InsertOrUpdate(new Course("Софтуер за научни изчисления (практикум)", "CSP", 4.0, "1", 9, 0));
				repository.InsertOrUpdate(new Course("Адитивни задачи в теорията на числата", "MAT", 9.0, "1", 9, 0));
				repository.InsertOrUpdate(new Course("Алгебра II", "MAT", 7.0, "1", 9, 0));
				repository.InsertOrUpdate(new Course("Алгебрична и хомотопична топология", "MAT", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Геометрия и топология", "MAT", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Изомонодромна деформация на линейни ОДУ с коефициенти рационални функции", "MAT", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Изпъкналост и диференцируемост в Банахови пространства", "MAT", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Комплексен анализ", "MAT", 9.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Коректно поставени задачи за еволюционни уравнения и системи", "MAT", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Логическо програмиране", "MAT", 9.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Математическа логика", "MAT", 8.5, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Небесна механика", "MAT", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Обща топология", "MAT", 8.5, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Представяния на компактни групи на Ли", "MAT", 8.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Приложение на групите на Ли в диференциалните уравнения", "MAT", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Риманова геометрия, избрани приложения, метод на Бохнер и теореми за анулиране", "MAT", 8.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Соболеви пространства и приложения в ЧДУ", "MAT", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Сплайн-функции и приложения", "MAT", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Състезания по математика за студенти - 2 част", "MAT", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Теория на Галоа", "MAT", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Теория на екстремалните задачи", "MAT", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Топология за информатици", "MAT", 5.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Увод в комутативната алгебра", "MAT", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Увод в съвременната теория на Частните диференциални уравнения", "MAT", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Функционален анализ", "MAT", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Функционални пространства и теория на интерполацията", "MAT", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Хамилтонови системи", "MAT", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Числено интегриране", "MAT", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Крайни геометрии", "MAT", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Езици за системно програмиране", "CSF", 6.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Приложения на крайните автомати", "CSF", 8.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Семантика на езиците за програмиране", "CSF", 5.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Управление на знания", "CSF", 5.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Дигитализирани екосистеми (Digitized Ecosystems) - на англ език", "CSF", 4.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Модели за управление на качеството 2", "CSF", 4.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Векторна компютърна графика", "CSF", 5.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Комуникации в реално време VoIP и видео разговори по Интернет", "CSF", 4.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Matlab и приложения в числените методи", "APM", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Алгоритмични основи на компютърната графика", "APM", 6.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Анализ на Клифорд за диференциални уравнения", "APM", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Геометрия на движението", "APM", 5.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Динамични системи", "APM", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Избрани теми от биоматематиката", "APM", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Математическа статистика", "APM", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Математически модели и изчислителен експеримент", "APM", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Математически увод в икономиката", "APM", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Методи за оптимизация", "APM", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Паралелни алгоритми", "APM", 9.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Случайни процеси", "APM", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Теория на нелинейните системи", "APM", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Теория на солитоните", "APM", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Увод в статистиката", "APM", 5.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Увод в теорията на динамичните системи и хаоса", "APM", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Фрактали", "APM", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Модели в социалните науки", "APM", 5.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Модели в социалните науки", "STAT", 5.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Модели на смъртност", "APM", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Модели на смъртност", "STAT", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Факторни планове", "APM", 5.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Факторни планове", "STAT", 5.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Биостатистика", "APM", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Биостатистика", "STAT", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Основи на статистическата обработка на естествен език", "APM", 4.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Основи на статистическата обработка на естествен език", "STAT", 4.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("ПРЕДПРИЕМАЧЕСТВО „Учебна компания (програма на „Джуниър Ачийвмънт)", "SEM", 5.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Семинар Допълнителни въпроси от ДИС", "SEM", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Семинар по Динамични системи и теория на числата - 2", "SEM", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Семинар по Диференциални уравнения", "SEM", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Семинар по Проектиране и интегриране на софтуерни системи", "SEM", 2.5, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Семинар по функционален анализ", "SEM", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Семинар по алгоритми - записването ще става при преподавателя,не през СУСИ 4", "SEM", 7.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Статистически методи в БДС", "STAT", 5.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Въведение в генетиката", "HUM", 3.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Убеждаваща комуникация и диалог", "HUM", 2.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Комуникативни умения", "HUM", 5.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Бази от данни", "CSC", 5.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Виртуализация и Cloud Computing", "CSC", 5.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Географски информационни системи", "CSC", 3.5, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Директорийни услуги", "CSC", 6.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Език за програмиране C#", "CSC", 6.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Електронно обучение", "CSC", 5.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Извличане на информация", "CSC", 6.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Компютърни мрежи (CCNA)", "CSC", 6.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Конкурентно програмиране", "CSC", 3.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Откриване на знания от данни", "CSC", 6.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Програмиране с Objective-C", "CSC", 5.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Проектиране на Java сървърни приложения", "CSC", 5.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Проектиране, разработка и оценка на образователен софтуер", "CSC", 5.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Разработване на ИКТ - базирано обучение", "CSC", 5.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Софтуерни шаблони за проектиране", "CSC", 5.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Съвременно уеб-програмиране с РНР", "CSC", 3.5, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("WAP &amp; WML &amp; XHTML", "CSC", 5.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Архитектурно моделиране и симулация на информационни системи", "CSC", 5.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Разработка на бизнес приложения със средствата на Java Enterprise Edition (Java EE)", "CSC", 4.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Програмиране с Python", "CSC", 5.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Съвременно функционално програмиране", "CSC", 5.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Практическо функционално програмиране с Clojure", "CSC", 5.0, "summer2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Информационните технологии в обучението на деца със специални образователни потребности", "DID", 2.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Комбинаторика, вероятности и статистика в училищния курс по математика", "DID", 5.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Специфични въпроси в обучението по информационни технологии", "DID", 5.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Дизайн и анализ на алгоритми - практикум", "CSP", 3.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Компютърни архитектури - практикум - спец КН", "CSP", 2.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Компютърни архитектури - практикум - спец СИ", "CSP", 2.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Логическо програмиране - практикум", "CSP", 2.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Операционни системи и офис приложения - практикум", "CSP", 2.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Програмиране 101", "CSP", 3.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Системи за управление на бази от данни (практикум) - спец ИС", "CSP", 2.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Структури от данни и програмиране - практикум - спец M", "CSP", 2.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Структури от данни и програмиране - практикум - спец И", "CSP", 2.5, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Структури от данни - практикум - спец ИС", "CSP", 2.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Увод в програмирането - практикум - спец Ст", "CSP", 2.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Увод в програмирането - практикум - спец ПМ", "CSP", 2.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Увод в програмирането - практикум - спец ИС", "CSP", 2.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Функционално програмиране - практикум", "CSP", 2.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Дескриптивна геометрия", "MAT", 7.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Диференциални уравнения ", "MAT", 7.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Диференциални уравнения и приложения с \"Mathematica\", \"Matlab\" или \"Maple\"", "MAT", 7.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Допълнение към курса по ДИС за компютърни специалности", "MAT", 6.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Елементи от алгебричната геометрия", "MAT", 7.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Линейни диференциални оператори", "MAT", 7.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Логическо програмиране ", "MAT", 9.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Структури върху гладки многообразия", "MAT", 9.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Състезания по математика за студенти - 1 част", "MAT", 7.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Теория на апроксимациите", "MAT", 7.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Теория на вероятностите 2", "MAT", 7.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Теория на диференчните схеми", "MAT", 7.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Теория на множествата", "MAT", 7.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Теория на мярката и интеграла (Интеграл на Лебег)", "MAT", 7.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Теория на разпределенията и трансформация на Фурие - спец И, М, ПМ", "MAT", 7.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Увод в аналитичната теория на числата", "MAT", 9.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Увод в теория на графите (екстрeмални задачи)", "MAT", 7.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Увод във функционалния анализ", "MAT", 8.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Числени методи за диференциални уравнения ", "MAT", 7.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Числени методи за системи с разредени матрици", "MAT", 9.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Бързи алгоритми върху структура от данни", "CSF", 5.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Граматики за генеративно изкуство", "CSF", 2.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Е-бизнес: стратегия, архитектура, проектиране", "CSF", 3.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Езици, автомати и изчислимост", "CSF", 6.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Изкуствен интелект", "CSF", 6.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Изчислимост и сложност", "CSF", 9.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Изчислителна геометрия", "CSF", 5.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Модели за управление на качеството", "CSF", 3.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Понятия  и структури в езиците за програмиране", "CSF", 5.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Съвременни комуникации", "CSF", 5.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Увод в състезателното програмиране", "CSF", 7.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Функционално програмиране ", "CSF", 5.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Елементи от теория на информацията", "CSF", 3.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Елементи от теория на информацията", "STAT", 3.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Дискретна оптимизация", "APM", 7.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Експериментални методи в механиката с практикум I", "APM", 7.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Компютърно геометрично моделиране", "APM", 8.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Макроикономика 2", "APM", 7.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Математическа екология", "APM", 5.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Математически модели във физиката", "APM", 9.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Метод на крайните елементи - алгоритмични основи", "APM", 7.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Механика на флуидите", "APM", 7.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Оптимално управление", "APM", 7.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Оптимизационна теория на графите", "APM", 7.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Преобразование на Фурие и Уейвлети-приложение в обработката на сигнали", "APM", 7.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Разклоняващи се процеси ", "APM", 7.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Размити множества и приложения", "APM", 5.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Теория на игрите", "APM", 7.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Теория на полугрупите и приложения", "APM", 7.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Увод в актюерството", "APM", 6.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Увод в актюерството", "STAT", 6.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Увод във времеви редове", "APM", 5.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Увод във времеви редове", "STAT", 5.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Вероятностни модели", "APM", 5.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Вероятностни модели", "STAT", 5.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Бейсов подход при анализа на данни", "SEM", 3.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Семинар по Динамични системи и теория на числата-1", "SEM", 7.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Семинар по компютърна алгебра, ортогонални полиноми и специални функции", "SEM", 7.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Семинар по Теория на вероятностите и математическа статистика", "SEM", 5.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Статистическа лаборатория (семинар)", "SEM", 5.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Учебен семинар по Частни диференциални уравнения", "SEM", 7.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Езикова култура", "HUM", 3.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Руски език за начинаещи", "HUM", 2.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Спорт****", "HUM", 2.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Fundamentals of Network security", "CSC", 5.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Дизайн и анализ на алгоритми", "CSC", 6.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Езици и среди за обучение", "CSC", 7.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Компютърна графика", "CSC", 5.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Многоплатформени мобилни приложения", "CSC", 3.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Обектно-ориентирано програмиране със C# NET", "CSC", 6.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Обектно-ориентирано програмиране с JAVA", "CSC", 6.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Основи на TCP/IP (в 4 и в 6)", "CSC", 5.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Практикум Компютърни мрежи (CCNA)", "CSC", 6.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Практическо програмиране с Perl", "CSC", 7.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Програмиране  за iOS", "CSC", 6.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Програмиране за ОС Android", "CSC", 3.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Програмиране с Ruby on Rails", "CSC", 5.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Системно програмиране на C за Linux", "CSC", 3.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Уеб приложения с ASP NET MVC", "CSC", 3.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Екология и опазване на околната среда", "HUM", 3.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Линукс системно администриране", "CSC", 5.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Разработка на iOS мобилни приложения", "CSC", 5.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Съвременни методи за многомерни апроксимации и геометрично моделиране", "APM", 7.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Френски език за начинаещи", "HUM", 2.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Структури от данни и програмиране - практикум - спец КН        ", "CSP", 2.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Линейни модели с R", "APM", 5.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Линейни модели с R", "STAT", 5.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Финансови модели с шокови влияния на пазара", "APM", 5.0, "winter2012/2013", 9, 0));
				repository.InsertOrUpdate(new Course("Финансови модели с шокови влияния на пазара   ", "STAT", 5.0, "winter2012/2013", 9, 0));
				repository.Save();
			}
		}
	}
}
