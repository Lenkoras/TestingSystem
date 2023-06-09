﻿using Database.Models;

namespace Database
{
    public class DatabaseSeeder : IDatabaseSeeder
    {
        public ApplicationDbContext Context { get; }

        public DatabaseSeeder(ApplicationDbContext context)
        {
            Context = context;
        }

        public void Seed()
        {
            if (!Context.Users.Any())
            {
                User user = new User()
                {
                    UserName = "lenkoras"
                };

                User user2 = new User()
                {
                    UserName = "xsiyrey"
                };

                user.Tests.Add(CreateTestSolarSystemPlanetsJupiter());

                user2.Tests.Add(CreateTestSolarSystem());

                Context.Users.AddRange(user, user2);

                Context.SaveChanges();
            }
        }

        private static Test CreateTestSolarSystem()
        {
            return new Test()
            {
                Name = "Солнечная система",
                Description = "Этот тест содержит вопросы по астрономии касаемо Солнечной системы",
                TestQuestions = new List<TestQuestion>()
                {
                    CreateTestQuestionTheBiggestSatelliteInSolarSystem(),
                    CreateTestQuestionTheSunStarKind(),
                    CreateTestQuestionPeriodOfRevolutionAroundTheSun()
                }
            };
        }

        private static TestQuestion CreateTestQuestionTheBiggestSatelliteInSolarSystem()
        {
            return new()
            {
                Text = "Самый большой спутник в Солнечной системе это ...",
                Answers = new List<QuestionAnswer>()
                {
                    new()
                    {
                        Text = "Европа"
                    },
                    new()
                    {
                        Text = "Фобоc"
                    },
                    new()
                    {
                        Text = "Ганимед",
                        IsCorrect = true
                    },
                    new()
                    {
                        Text = "Каллисто"
                    }
                }
            };
        }

        private static TestQuestion CreateTestQuestionTheSunStarKind()
        {
            return new()
            {
                Text = "Солнце – типичный представитель этого класса звезд:",
                Answers = new List<QuestionAnswer>()
                {
                    new()
                    {
                        Text = "Красный карлик"
                    },
                    new()
                    {
                        Text = "Жёлтый карлик",
                        IsCorrect = true
                    },
                    new()
                    {
                        Text = "Белый карлик"
                    },
                    new()
                    {
                        Text = "Красный гигант"
                    }
                }
            };
        }

        private static TestQuestion CreateTestQuestionPeriodOfRevolutionAroundTheSun()
        {
            return new()
            {
                Text = "Период обращения Сатурна вокруг Солнца?",
                Answers = new List<QuestionAnswer>()
                {
                    new()
                    {
                        Text = "2 года"
                    },
                    new()
                    {
                        Text = "5 лет"
                    },
                    new()
                    {
                        Text = "29 лет",
                        IsCorrect = true
                    }
                }
            };
        }

        private static Test CreateTestSolarSystemPlanetsJupiter()
        {
            return new Test()
            {
                Name = "Планеты Солнечной системы: Юпитер",
                Description = "Этот тест содержит вопросы по астрономии касаемо планеты Юпитер",
                TestQuestions = new List<TestQuestion>()
                {
                    CreateTestQuestionJupitersPositionInSolarSystem(),
                    CreateTestQuestionDistinctiveFeatureOfJupiter(),
                    CreateTestQuestionNaturalSatelliteOfJupiter()
                }
            };
        }

        private static TestQuestion CreateTestQuestionNaturalSatelliteOfJupiter()
        {
            return new()
            {
                Text = "Один из естественных спутников Юпитера называется ...",
                Answers = new List<QuestionAnswer>()
                {
                    new()
                    {
                        Text = "Деймос"
                    },
                    new()
                    {
                        Text = "Титан"
                    },
                    new()
                    {
                        Text = "Каллисто",
                        IsCorrect = true
                    }
                }
            };
        }

        private static TestQuestion CreateTestQuestionDistinctiveFeatureOfJupiter()
        {
            return new()
            {
                Text = "Какая существует характерная особенность Юпитера по сравнению с другими планетами Солнечной системы.",
                Answers = new List<QuestionAnswer>()
                {
                    new()
                    {
                        Text = "Большое красное пятно",
                        IsCorrect = true
                    },
                    new()
                    {
                        Text = "Ярко выраженные кольца вокруг планеты"
                    },
                    new()
                    {
                        Text = "Снежные шапки в полярных областях"
                    }
                }
            };
        }

        private static TestQuestion CreateTestQuestionJupitersPositionInSolarSystem()
        {
            return new()
            {
                Text = "Какой по счету планетой от Солнца является Юпитер?",
                Answers = new List<QuestionAnswer>()
                {
                    new()
                    {
                        Text = "Третьей"
                    },
                    new()
                    {
                        Text = "Пятой",
                        IsCorrect = true
                    },
                    new()
                    {
                        Text = "Шестой"
                    }
                }
            };
        }
    }
}
