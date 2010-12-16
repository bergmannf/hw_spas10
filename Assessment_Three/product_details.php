<?php
include './includes/config.inc.php';
include MYSQL;
include './includes/form_functions.inc.php';

redirect_invalid_user();

include './includes/header.php';
include './includes/sidebar.php';

$order_errors = array();

if ($_SERVER['REQUEST_METHOD'] == 'POST') {
	$productid = $_POST['id'];
	$product = get_product_by_id($productid);
	$quantity = $_POST['quantity'];
	if (empty($quantity) || !is_numeric($quantity)) {
		$order_errors['quantity'] = 'The provided quantity was either empty or no number. Please correct your input.';
	}
	if (empty($order_errors)) {
		try {
			$product->quantity = $quantity;
			$shopping_cart = $_SESSION['cart'];
			if (isset($_POST['add'])) {
				$shopping_cart->add_item_increase_quantity($product);
				$added = true;
			} else {
				$shopping_cart->add_item($product);
				$added = true;
			}
		} catch (Exception $e) {
			$is_error = $e;
		}
	}
}
$productid = $_GET['id'];
if (isset($productid)) {
	$product = get_product_by_id($productid);
}
?>
<div id="content" class="column-right">
	<?php
	if (isset($is_error)) {
		echo '<div class="error">Can not enter a negative quantity!</div>';
	}
	if (isset($added)) {
		echo '<div class="success">The product was successfully added to your shopping cart.</div>';
	}
	?>
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
	<form action="" method="post" accept-charset="utf-8">
		<p>
			<label for="quantity"><strong>Quantity:</strong></label>
			<br/>
			<?php create_form_input('quantity', 'text', $order_errors) ?>
		</p>
		<p>
			<label for="add">
				<strong>Add to current quantity?</strong>
			</label>
			<input type="checkbox" name="add" value="add" id="add"/>
		</p>
		<p>
			<input type="hidden" name="id" <?php echo 'value="' . $productid . '"' ?>/>
		</p>
		<p>
			<input type="submit" name="submit_button" value="Add to cart &rarr;" id="submit_button" class="formbutton"/>
		</p>
	</form>
</div>
<?php
			include './includes/footer.php';
?>