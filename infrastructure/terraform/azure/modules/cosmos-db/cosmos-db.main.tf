## Azure Cosmos DB ##

resource "azurerm_cosmosdb_account" "cosmosdb_account" {
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

resource "azurerm_cosmosdb_sql_database" "cosmosdb_database" {
    name                = var.database_name
    resource_group_name = var.resource_group_name
    account_name        = var.name
    throughput          = 400
}

// Todo: Move containers to loop

resource "azurerm_cosmosdb_sql_container" "example" {
    name                = var.container_name
    resource_group_name = var.resource_group_name
    account_name        = var.name
    database_name       = var.database_name
    partition_key_path  = "/Platform"
    throughput          = 400
}