﻿using System;
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
		public DateTimeOffset Now(string tz)
		{
			var clock = SystemClock.Instance;
			Instant now = clock.Now;
			var zone = DateTimeZoneProviders.Tzdb[tz];
			return now.InZone(zone).ToDateTimeOffset();
		}

		[Route("convert")]
		[HttpGet]
		public DateTime Get(DateTime time, string fromTZ, string toTZ)
		{			
			LocalDateTime fromLocal = LocalDateTime.FromDateTime(time);
			DateTimeZone fromZone = DateTimeZoneProviders.Tzdb[fromTZ];
			ZonedDateTime fromZoned = fromLocal.InZoneLeniently(fromZone);

			DateTimeZone toZone = DateTimeZoneProviders.Tzdb[toTZ];
			ZonedDateTime toZoned = fromZoned.WithZone(toZone);
			LocalDateTime toLocal = toZoned.LocalDateTime;
			return toLocal.ToDateTimeUnspecified();
		}

	}
}
