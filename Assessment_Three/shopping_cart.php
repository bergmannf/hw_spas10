<?php
include './includes/config.inc.php';
include MYSQL;

redirect_invalid_user();

include './includes/form_functions.inc.php';

include './includes/header.php';
include './includes/sidebar.php';

if ($_SERVER['REQUEST_METHOD'] == 'POST') {
	$quantity = $_POST['quantity'];
	if (isset($_POST['edit'])) {
		try {
			$edit = $_POST['edit'];
			$product = $_SESSION['cart']->get_item_for_id($edit);
			$product->set_quantity($_POST['quantity']);
			$_SESSION['cart']->add_item($product);
		} catch (Exception $e) {
			$is_error = $e;
		}
	}
	if (isset($_POST['delete'])) {
		try {
			$delete = $_POST['delete'];
			$product = $_SESSION['cart']->get_item_for_id($delete);
			$_SESSION['cart']->remove_item($product);
		} catch (Exception $e) {
			$is_error = $e;
		}
	}
}

$items = $_SESSION['cart']->get_items();
$sum = 0;
?>
<div id="content" class="column-right">
	<?php
	if (isset($is_error)) {
		echo '<div class="error">Either item was not found, or quantity turned negative.</div>';
	} else {
		if (isset($delete)) {
			echo '<div class="success">Item successfully deleted.</div>';
		}
		if (isset($edit)) {
			echo '<div class="success">Quantity successfully changed.</div>';
		}
	}
	?>
	<h1>
		Shopping Cart
	</h1>
	<?php
	if (isset($items)) {
	?>
		<table>
			<thead>
			<th>
				Item
			</th>
			<th>
				Quantity
			</th>
			<th>
				Price
			</th>
			</thead>
			<tbody>
			<?php foreach ($items as $value) {
			?>
				<tr>
					<td>
					<?php echo '<a href=product_details.php?id=' . $value->itemId . '>' . $value->title . '</a>'; ?>
				</td>
				<td>
					<form action="" method="post" accept-charset="utf-8">
						<input type="text" <?php echo 'name="quantity" id="quantity" value="' . $value->quantity . '"'; ?>/>
						<button type="submit" <?php echo 'name="delete" id="delete" value="' . $value->itemId . '"'; ?>><img src="images/shopping-basket--minus.png"/> Delete</button>
						<button type="submit" <?php echo 'name="edit" id="edit" value="' . $value->itemId . '"'; ?>><img src="images/shopping-basket--pencil.png"/> Edit</button>
					</form>
				</td>
				<td>
					<?php $sum += $value->cost * $value->quantity;
					echo $value->cost; ?>
				</td>
			</tr>
			<?php
				}
			?>
				<tr>
					<td>
						<strong>Sum:</strong>
					</td>
					<td></td>
					<td>
					<?php echo $sum; ?>
				</td>
			</tr>
		</tbody>
	</table>
	<?php
				} else {
					echo 'Your shopping cart is empty';
				}
	?>
			</div>
<?php
				include './includes/footer.php';
?>