<?php

require 'my_collection.php';

/**
 * 
 **/
class ShoppingCart implements MyCollection
{
	var $items;

	function __construct()
	{

	}

	/**
	 * Adds an item to the shopping cart.
	 * 
	 * @param <type> $article_number The article number of the article that shall be added to the cart.
	 * @param <type> $quantity The quantity that shall be added to the cart.
	 */
	public function add_item($article_number, $quantity)
	{
		$this->items[$article_number] += $quantity;
	}

	/**
	 * Removes a number of items from the shopping cart
	 *
	 * @param $article_number The article number of the article that shall be removed from the cart.
	 * @param $quantity The quantity that shall be removed from the cart.
	 */
	public function remove_item($article_number, $quantity)
	{
		if (array_key_exists($article_number, $this->items)) {
			if ($this->items[$article_number] > $quantity) {
				$this->items[$article_number] -= $quantity;
			}
			else if ($this->items[$article_number] == $quantity) {
				unset($this->items[$article_number]);
			}
			else {
				throw new Exception("Can not remove more items than are present");
			}
		}
	}
}
?>
