using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP324_lina
{
    internal class Program
    {
        Random rand = new Random();
        class Gamer
        {
            private double health = 100;
            public double Health
            {
                set
                {
                    if (value < 0) { 
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n~ ВЫ УМЕРЛИ! ~");
                        Console.ResetColor();
                        return; 
                    }
                    else if (value > 100) { Console.WriteLine("\n - Ошибкинс! Больше 100HP быть не может! - "); return; }
                    health = value;
                }
                get { return health; }
            }

            public Dictionary<string, int> weapon = new Dictionary<string, int>()
            {
                { "Деревянный меч", 10 }
            };
            public Dictionary<string, int> Weapon
            {
                set
                {
                    if (value.Count <= 0) { Console.WriteLine(" !- У ВАС НЕТ ОРУЖИЯ -! "); return; }
                    // if оружия больше, чем 2
                    weapon = value;
                }
                get { return weapon; }
            }

            public Dictionary<string, int> armor = new Dictionary<string, int>()
            {
                { "Жабья кожа", 5 }
            };
            public Dictionary<string, int> Armor
            {
                set
                {
                    if (value.Count <= 0) { Console.WriteLine(" !- У ВАС НЕТ ДОСПЕХ -! "); return; }
                    // if оружия больше, чем 2
                    armor = value;
                }
                get { return armor; }
            }
            public void Info()
            {
                Console.WriteLine("+++ ВАШЕ ТЕКУЩЕЕ СОСТОЯНИЕ +++" +
                    $"\n\tЗдоровье: {Health}" +
                    $"\n\tОружие: {Weapon.Keys}" +
                    $"\n\tДоспехи: {Armor}");
            }
        }

        public abstract class Villian
        {
            public abstract string Name { get; /*set;*/ }
            public abstract decimal Health { get; set;  }
            public abstract decimal Attack { get; /*set;*/ }
            public abstract decimal Protection { get; /*set;*/ }
            public abstract decimal Crit_dam { get; /*set;*/ } // default 3%
            public abstract decimal Froze_chance { get; /*set;*/ } // default 0

            public void Info()
            {
                Console.WriteLine($"\n=== {Name.ToUpper()} ===" +
                    $"\n\tЗдоровье: {Health}НР" +
                    $"\n\tАтака: {Attack}НР" +
                    $"\n\tЗащита: {Protection}%" +
                    $"\n\tКрит.шанс: {Crit_dam}%" +
                    $"\n\tШанс заморозки: {Froze_chance}%");
            }
        }

        class Goblin : Villian
        {
            public override string Name => "Гоблин-блин";
            protected decimal health = 80;
            public override decimal Health
            {
                set
                {
                    if (value <= 0) { Console.WriteLine("$- ГОБЛИН ПОВЕРЖЕН! -$"); return; }
                    health = value;
                }
                get { return health; }
            }
            public override decimal Attack => 15m;
            public override decimal Protection => 10m;
            public override decimal Crit_dam => 10m;
            public override decimal Froze_chance => 0m;
        }

        class Skeleton : Villian
        {
            public override string Name => "Скелет-велосипед";
            protected decimal health = 100;
            public override decimal Health
            {
                set
                {
                    if (value <= 0) { Console.WriteLine("$- СКЕЛЕТ ПОВЕРЖЕН! -$"); return; }
                    health = value;
                }
                get { return health; }
            }
            public override decimal Attack => 15m;
            public override decimal Protection => 15m;
            public override decimal Crit_dam => 10m;
            public override decimal Froze_chance => 0m;
        }

        class Wizard : Villian
        {
            public override string Name => "Маг-макдак";
            protected decimal health = 150;
            public override decimal Health
            {
                set
                {
                    if (value <= 0) { Console.WriteLine("$- МАГ ПОВЕРЖЕН! -$"); return; }
                    health = value;
                }
                get { return health; }
            }
            public override decimal Attack => 25m;
            public override decimal Protection => 35m;
            public override decimal Crit_dam => 20m;
            public override decimal Froze_chance => 10m;
        }

        class VVG : Goblin //Сохраняет: шанс критического удара.
        {
            /*Здоровье ×2.0 от базового гоблина.
             * Атака ×1.5.
             * Защита ×1.2.
             * Шанс крита +10%. к значению обычного гоблина.*/
            public override string Name => "ВВГ (раса гоблинов)";
            public override decimal Health
            {
                set
                {
                    if (value <= 0) { Console.WriteLine("!$%*- ВВГ ПОВЕРЖЕН! -*%$!"); return; }
                    health = value;
                }
            }
            public VVG()
            {
                health = 160m;
            }
            public override decimal Attack => base.Attack * 1.5m;
            public override decimal Protection => base.Protection * 1.2m;
            public override decimal Crit_dam => base.Crit_dam + 10m;
        }

        class Kovalskiy : Skeleton //Сохраняет: полностью игнорирует защиту игрока.
        {
            /*Здоровье ×2.5.
             * Атака ×1.3.
             * Защита ×1.4.*/
            public override string Name => "Ковальский (раса скелет)";
            public override decimal Health
            {
                set
                {
                    if (value <= 0) { Console.WriteLine("!$%*- КОВАЛЬСКИЙ ПОВЕРЖЕН! -*%$!"); return; }
                    health = value;
                }
            }
            public Kovalskiy()
            {
                health = 250m;
            }
            public override decimal Attack => base.Attack * 1.3m;
            public override decimal Protection => base.Protection * 1.4m;

        }

        class Archimag : Wizard //Сохраняет: шанс наложить заморозку (пропуск хода).
        {
            /*Здоровье ×1.8.
             * Атака ×1.6.
             * Защита ×1.1.
             * Шанс заморозки +10%. к значению обычного мага.*/
            public override string Name => "Архимаг С++ (раса магов)";
            public override decimal Health
            {
                set
                {
                    if (value <= 0) { Console.WriteLine("!$%*- АРХИМАГ С++ ПОВЕРЖЕН! -*%$!"); return; }
                    health = value;
                }
            }
            public Archimag()
            {
                health = 270m;
            }
            public override decimal Attack => base.Attack * 1.6m;
            public override decimal Protection => base.Protection * 1.1m;
            public override decimal Froze_chance => base.Froze_chance + 10m;
        }

        class Pestov : Skeleton //Сохраняет: полностью игнорирует защиту игрока.
        {
            /*Здоровье ×1.3.
             * Атака ×1.8.
             * Защита ×0.6.
             * Шанс заморозки +15%. к значению обычного мага.*/
            public override string Name => "Пестов С-- (раса скелетов)";
            public override decimal Health
            {
                set
                {
                    if (value <= 0) { Console.WriteLine("!$%*- ПЕСТОВ С-- ПОВЕРЖЕН! -*%$!"); return; }
                    health = value;
                }
            }
            public Pestov()
            {
                health = 130m;
            }
            public override decimal Attack => base.Attack * 1.8m;
            public override decimal Protection => base.Protection * 0.6m;
            public override decimal Froze_chance => base.Froze_chance + 20m;
        }
        Dictionary<string, int> items = new Dictionary<string, int>()
        {
            { "Палка копалка", 25 },
            { "Меч кладенец", 40 },
            { "Хвост кошки", 60 },
            { "Золотая сковородка", 100 },
            { "Лечебное зелье", 100 },
            { "Гематогенка", 50 },
            { "Мантия невидимка", 100 },
            { "Кожа дракона", 50 }
        };

        static Gamer g = new Gamer();

        void MysteryCase()
        {
            Console.WriteLine("- Вы нашли сундук!!! -");
            var rand_item = items.ElementAt(rand.Next(items.Count));
            Console.WriteLine($"$% ПОЗДРАВЛЯЕМ! Вы нашли новую вещь:");
            if (rand_item.Key.Contains("Лечебное зелье") || rand_item.Key.Contains("Гематогенка"))
            {
                Console.WriteLine($"{rand_item.Key}, лечащее на {rand_item.Value}HP!");
                g.Health += rand_item.Value;
                if (g.Health > 100)
                {
                    g.Health = 100;
                    Console.WriteLine($"~ Вы полностью исцелились! HP: {g.Health} ~");
                }
                else
                {
                    Console.WriteLine($"~ Вы полностью исцелились! HP: {g.Health} ~");
                }
            }
            if (rand_item.Key.Contains("Мантия невидимка") || rand_item.Key.Contains("Кожа дракона"))
            {
                Console.WriteLine($"{rand_item.Key}, защищающее на {rand_item.Value}%!");
                Console.Write("- Забрать или бросить? (да/нет): ");
                string ans = Console.ReadLine().Trim().ToLower();
                switch (ans)
                {
                    case "да":
                        g.Armor.Clear();
                        g.Armor.Add(rand_item.Key, rand_item.Value);
                        Console.WriteLine($"~ Вы забрали {rand_item.Key}! ~");
                        g.Info();
                        break;
                    case "нет":
                        Console.WriteLine("- Ну... Идём дальше! ");
                        g.Info();
                        break;
                    default:
                        Console.WriteLine("- Ничего не понятно, но очень интересно... Иди c богом!\n");
                        break;
                }
            }
            else
            {
                Console.WriteLine($"~ {rand_item.Key}, сбивающее на {rand_item.Value}HP! ~");
                Console.Write("- Забрать или бросить? (да/нет): ");
                string ans2 = Console.ReadLine().Trim().ToLower();
                switch (ans2)
                {
                    case "да":
                        g.Weapon.Clear();
                        g.Weapon.Add(rand_item.Key, rand_item.Value);
                        Console.WriteLine($"~ Вы забрали {rand_item.Key}! ~");
                        g.Info();
                        break;
                    case "нет":
                        Console.WriteLine("-*- Ну... Идём дальше! ");
                        g.Info();
                        break;
                    default:
                        Console.WriteLine("-*- Ничего не понятно, но очень интересно... Иди c богом!\n");
                        break;
                }
            }
        }



        static void Main(string[] args)
        {
            
        }
    }
}
