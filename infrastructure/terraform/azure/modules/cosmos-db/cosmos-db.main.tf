## Azure Cosmos DB ##

resource "azurerm_cosmosdb_account" "cosmos_db" {
    name                        = var.name
    resource_group_name         = var.resource_group_name
    location                    = var.location
    offer_type                  = "Standard"
    kind                        = "GlobalDocumentDb"
    enable_automatic_failover   = true

    consistency_policy {
        consistency_level       = "Session"
    }

    geo_location {
        location                = var.location
        failover_priority       = 0
    }
}