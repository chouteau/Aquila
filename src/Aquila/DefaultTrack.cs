namespace Aquila
{
    public class DefaultTrack : TrackBuilder
	{
		public DefaultTrack() : base()
		{

		}

		protected override string HitType
		{
			get { return "pageview"; }
		}
	}
}
