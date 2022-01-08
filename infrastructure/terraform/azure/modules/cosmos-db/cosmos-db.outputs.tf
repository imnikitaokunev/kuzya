output "endpoint" {
    value = azurerm_cosmosdb_account.cosmos_db.endpoint
}

output "primary_key" {
    value = azurerm_cosmosdb_account.cosmos_db.primary_key
}

output "connection_strings" {
    value = azurerm_cosmosdb_account.cosmos_db.connection_strings
}