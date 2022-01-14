﻿namespace Application.Onliner;

internal class OnlinerApartmentDto
{
    public long Id { get; set; }
    public string Url { get; set; }
    public string Platform => "Onliner";
    public OnlinerPriceDto Price { get; set; }
    public OnlinerContactDto Contact { get; set; }
}
