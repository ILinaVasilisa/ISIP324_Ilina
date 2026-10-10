using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP324_lina
{
    internal class Program
    {
        class Gamer
        {
            private double health = 100;
            public double Health
            {
                set
                {
                    if (value < 0) { Console.WriteLine("\n~ ВЫ УМЕРЛИ! ~"); return; }
                    else if (value > 100) { Console.WriteLine("\n - Ошибкинс! Больше 100HP быть не может!"); return; }
                    health = value;
                }
                get { return health; }
            }

            private string weapon = "Деревянный меч";
            public string Weapon
            {
                set
                {
                    if (string.IsNullOrEmpty(value)) { Console.WriteLine(" !- У ВАС НЕТ ОРУЖИЯ -! "); return; }
                    // if оружия больше, чем 2
                    weapon = value;
                }
                get { return weapon; }
            }

            private string armor = "Жабья кожа";
            public string Armor
            {
                set
                {
                    if (string.IsNullOrEmpty(value)) { Console.WriteLine(" !- У ВАС НЕТ ДОСПЕХ -! "); return; }
                    // if оружия больше, чем 2
                    armor = value;
                }
                get { return armor; }
            }
            public void Info()
            {
                Console.WriteLine("+++ ВАШЕ ТЕКУЩЕЕ СОСТОЯНИЕ +++" +
                    $"\n\tЗдоровье: {Health}" +
                    $"\n\tОружие: {Weapon}" +
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

        static void Main(string[] args)
        {
            
        }
    }
}
