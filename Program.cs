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
            public decimal health = 80;
            public override decimal Health
            {
                set
                {
                    if (health < 0) { Console.WriteLine("$- ГОБЛИН ПОВЕРЖЕН! -$"); return; }
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
            public decimal health = 100;
            public override decimal Health
            {
                set
                {
                    if (health < 0) { Console.WriteLine("$- СКЕЛЕТ ПОВЕРЖЕН! -$"); return; }
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
            public decimal health = 100;
            public override decimal Health
            {
                set
                {
                    if (health < 0) { Console.WriteLine("$- МАГ ПОВЕРЖЕН! -$"); return; }
                    health = value;
                }
                get { return health; }
            }
            public override decimal Attack => 25m;
            public override decimal Protection => 35m;
            public override decimal Crit_dam => 20m;
            public override decimal Froze_chance => 10m;
        }



        static void Main(string[] args)
        {
            
        }
    }
}
