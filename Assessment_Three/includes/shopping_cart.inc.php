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
		if ($item->quantity > 0) {
			if (array_key_exists($itemId, $this->items)) {
				unset($this->items[$itemId]);
			}
			$this->items[$itemId] = $item;
		} else {
			throw new Exception("No negative quantity permitted.");
		}
	}

	function add_item_increase_quantity($item) {
		$itemId = $item->itemId;
		if (array_key_exists($itemId, $this->items)) {
			$currentQuantity = $this->items[$itemId]->quantity;
			if (($item->quantity > 0) || (($currentQuantity - $item->quantity) > 0)) {
				$this->items[$itemId]->quantity = $currentQuantity + $item->quantity;
			} else {
				throw new Exception("No negative quantity permitted.");
			}
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
		if (array_key_exists($itemId, $this->items)) {
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

	function get_item_for_id($itemId) {
		if (array_key_exists($itemId, $this->items)) {
			return $this->items[$itemId];
		} else {
			throw new Exception("Item does not exist");
		}
	}

}

?>