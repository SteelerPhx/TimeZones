using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Linq;
using NodaTime;
using NodaTime.TimeZones;

namespace TimeZones.Controllers
{
	[RoutePrefix("api/timezones")]
	public class TimeZonesController: ApiController
	{		
		public TimeZonesController()
		{			
		}

		[Route("list")]
		[HttpGet]
		public IEnumerable<string> List()
		{
			return DateTimeZoneProviders.Tzdb.Ids;

		}

		[Route("")]
		[HttpGet]
		public DateTimeZone Get(string tz)
		{
			return DateTimeZoneProviders.Tzdb[tz];
		}

		[Route("now")]
		[HttpGet]
		public ZonedDateTime Now(string tz)
		{
			var clock = SystemClock.Instance;
			Instant now = clock.Now;
			var zone = DateTimeZoneProviders.Tzdb[tz];
			return now.InZone(zone);
		}

		//[Route("convert")]
		//[HttpGet]
		//public DateTime Get(string fromTZ, string toTZ, DateTimeOffset time)
		//{			
		//	// convert passed DateTimeOffset to utc moment
		//	var momentTime = Moment.Create(time.UtcDateTime);

		//	// get raw from/to timezones
		//	var fromTimeZone = this.tzUseCases.GetTimeZoneWithIanaId(fromId);
		//	var toTimeZone = this.tzUseCases.GetTimeZoneWithIanaId(toId);

		//	//var isDst = fromTimeZone.GetDstOffset(momentTime) != fromTimeZone.GetRawOffset(momentTime);

		//	// determine the offset for "from" timezone
		//	var fromOffset = fromTimeZone.GetDstOffset(momentTime);
		//	// determine the offset for "to" timezone
		//	var toOffset = toTimeZone.GetDstOffset(momentTime);

		//	// get the diff (this timespan will be added to the original time
		//	var diff = toOffset - fromOffset;
		//	return time.Add(diff);
		//}

	}
}
