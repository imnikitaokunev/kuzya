output "endpoint" {
    value = azurerm_cosmosdb_account.cosmosdb_account.endpoint
}

output "primary_key" {
    value = azurerm_cosmosdb_account.cosmosdb_account.primary_key
}

output "connection_strings" {
    value = azurerm_cosmosdb_account.cosmosdb_account.connection_strings
}