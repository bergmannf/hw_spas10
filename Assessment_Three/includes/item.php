<?php
class Item {

	public $itemId;
	public $quantity;
	public $title;
	public $authorId;
	public $publisher;
	public $subject;
	public $cost;
	public $stock;

	function  __construct($itemId, $quantity, $title, $authorId, $publisher, $subject, $cost, $stock) {
		$this->itemId = $itemId;
		$this->quantity = $quantity;
		$this->title = $title;
		$this->authorId = $authorId;
		$this->publisher = $publisher;
		$this->subject = $subject;
		$this->cost = $cost;
		$this->stock = $stock;
	}
}
?>
