<?php
include './includes/config.inc.php';
include MYSQL;
include './includes/form_functions.inc.php';

redirect_invalid_user();

include './includes/header.php';
include './includes/sidebar.php';

$order_errors = array();
$productid = $_GET['id'];
if (isset($productid)){
	$product = get_product_by_id($productid);
}
?>
<div id="content" class="column-right">
	<h1>
		<?php echo $product->title ?>
	</h1>
	<h2>
		<?php echo $product->authorId ?>
	</h2>
	<p>
		<strong>
			Subject:
		</strong>
		<?php echo $product->subject; ?>
	</p>
	<p>
		<strong>
			Cost:
		</strong>
		<?php echo $product->cost; ?>
	</p>
	<p>
		<strong>
			Available:
		</strong>
		<?php echo $product->stock; ?>
	</p>
	<form action="shoppingcart.php" method="post" accept-charset="utf-8">
		<p>
			<label for="quantity"><strong>Quantity:</strong></label>
			<br/>
			<?php create_form_input('quantity', 'text', $order_errors) ?>
		</p>
		<p>
			<input type="submit" name="submit_button" value="Add to cart &rarr;" id="submit_button" class="formbutton"/>
		</p>
	</form>
</div>
<?php
include './includes/footer.php';
?>