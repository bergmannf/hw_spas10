<?php

/**
 * A shopping cart holding the products a user wants to buy.
 */
class ShoppingCart {

	private $items;

	function __construct() {
		$this->items = array();
	}

	/**
	 *
	 * @param <type> $item
	 */
	function add_item($item) {
		$itemId = $item->itemId;
		if (array_key_exists($itemId, $this->items)) {
			unset($this->items[$itemId]);
		}
		$this->items[$itemId] = $item;
	}

	function add_item_increase_quantity($item) {
		$itemId = $item->itemId;
		if (array_key_exists($itemId, $this->items)) {
			$currentQuantity = $this->items[$itemId]->quantity;
			$this->items[$itemId]->quantity = $currentQuantity + $item->quantity;
		} else {
			$this->add_item($item);
		}
	}

	/**
	 *
	 * @param <type> $item
	 */
	function remove_item($item) {
		$itemId = $item->itemId;
		if (array_key_exists($itemId, $searcharray)) {
			unset($this->items[$itemId]);
		} else {
			throw new Exception("Element $item not found in shopping cart.");
		}
	}

	/**
	 *
	 * @return <type>
	 */
	function get_items() {
		return $this->items;
	}

}

?>