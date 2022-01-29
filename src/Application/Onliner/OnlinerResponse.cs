namespace Application.Onliner;

internal class OnlinerResponse
{
    public IEnumerable<OnlinerApartmentDto> Apartments { get; set; }
    public int Total { get; set; }
}


/* Example of response

{
  "apartments":[
    {
      "id":391502,
      "price":{
        "amount":"270.00",
        "currency":"USD",
        "converted":{
          "BYN":{
            "amount":"689.99",
            "currency":"BYN"
          },
          "USD":{
            "amount":"270.00",
            "currency":"USD"
          }
        }
      },
      "rent_type":"1_room",
      "location":{
        "address":"\u041c\u0438\u043d\u0441\u043a, \u0443\u043b\u0438\u0446\u0430 \u041a\u0435\u0434\u044b\u0448\u043a\u043e, 13",
        "user_address":"\u041c\u0438\u043d\u0441\u043a, \u0443\u043b\u0438\u0446\u0430 \u041a\u0435\u0434\u044b\u0448\u043a\u043e, 13",
        "latitude":53.93077945,
        "longitude":27.6161429445326
      },
      "photo":"https:\/\/content.onliner.by\/apartment_rentals\/2695693\/600x400\/97ed3d49ac900bf09fd4a0427ddfdbc0.jpeg",
      "contact":{
        "owner":true
      },
      "created_at":"2019-03-18T17:49:46+0300",
      "last_time_up":"2022-01-15T17:00:34+0300",
      "up_available_in":86291,
      "url":"https:\/\/r.onliner.by\/ak\/apartments\/391502"
    },
  ],
  "total":2487,
  "page":{
    "limit":36,
    "items":36,
    "current":1,
    "last":70
  }
}
 
 */