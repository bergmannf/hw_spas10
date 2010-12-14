<?php

/**
 * A shopping cart holding the products a user wants to buy.
 */
class ShoppingCart {

	private $items;

	function __construct() {
		$items = array();
	}

	/**
	 *
	 * @param <type> $item
	 */
	function addItem($item) {
		$itemId = $item->itemId();
		if (array_key_exists($itemId, $this->items)) {
			$currentQuantity = $this->items[$itemId]->quantity();
			$this->items[$itemId] = currentQuantity + $item->quantity();
		} else {
			$this->items[$itemId] = $item;
		}
	}

	/**
	 *
	 * @param <type> $item
	 */
	function removeItem($item) {
		$itemId = $item->itemId();
		if (array_key_exists($itemId, $searcharray)) {
			unset($this->items[$itemId]);
		}
		else {
			throw new Exception("Element $item not found in shopping cart.");
		}
	}

}
?>