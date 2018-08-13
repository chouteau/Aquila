using System.Web;

namespace Aquila
{
    public class EventTrack : TrackBuilder
    {
        public EventTrack() : base()
        {
        }

        public EventTrack(HttpContextBase ctx) : base(ctx)
        {
        }

        protected override string HitType
        {
            get { return "event"; }
        }

        public int? Value
        {
            get
            {
                return m_Track.EventValue;
            }
            set
            {
                m_Track.EventValue = value;
            }
        }

        public string Label
        {
            get
            {
                return m_Track.EventLabel;
            }
            set
            {
                m_Track.EventLabel = value;
            }
        }

        public string Action
        {
            get
            {
                return m_Track.EventAction;
            }
            set
            {
                m_Track.EventAction = value;
            }
        }

        public string Category
        {
            get
            {
                return m_Track.EventCategory;
            }
            set
            {
                m_Track.EventCategory = value;
            }
        }
    }
}