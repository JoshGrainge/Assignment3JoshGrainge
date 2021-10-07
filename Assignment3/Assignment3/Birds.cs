using System;

using A3.Eggs;
namespace A3.Birds
{
	abstract class Bird
	{
		public static Random Rand = new Random(1);

        /// <summary>
        /// Return array of eggs of user specified length. Creates eggs randomly for each index of array
        /// </summary>
        /// <param name="numEggs"></param>
        /// <returns></returns>
        public abstract Egg[] LayEggs(int numEggs);

        /// <summary>
        /// Create new egg within size range and with specified color. Has specified chance to be a broken egg
        /// </summary>
        /// <param name="minSize"></param>
        /// <param name="maxSize"></param>
        /// <param name="brokenChance"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        protected Egg GetEgg(double minSize, double maxSize, double brokenChance, Egg.Colors color)
        {
            double eggSize = Rand.NextDouble() * (maxSize - minSize) + minSize;

            if (Rand.NextDouble() <= brokenChance)
                return new BrokenEgg(eggSize, color);
            else
                return new Egg(eggSize, color);
        }
	}

	class Chicken : Bird
	{
        public override Egg[] LayEggs(int numEggs)
        {
            Egg[] eggs = new Egg[numEggs];
            for (int i = 0; i < numEggs; i++)
                eggs[i] = GetEgg(2, 4, 0.25, Egg.Colors.brown);

            return eggs;
        }
    }

	class Ostrich : Bird 
	{
        public override Egg[] LayEggs(int numEggs)
        {
            Egg[] eggs = new Egg[numEggs];
            for (int i = 0; i < numEggs; i++)
                eggs[i] = GetEgg(10, 15, 0.45, Egg.Colors.speckled);

            return eggs;
        }
    }
}
