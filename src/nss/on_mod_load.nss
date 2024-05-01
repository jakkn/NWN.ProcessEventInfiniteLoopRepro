#include "nwnx_events"

void main() {
  NWNX_Events_SubscribeEvent("NWNX_ON_STORE_REQUEST_SELL_BEFORE", "on_sell_before");
}