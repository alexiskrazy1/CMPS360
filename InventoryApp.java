package a1b;

import javax.swing.JOptionPane;

public class InventoryApp {
    public static void main(String[] args) {
        Product product1 = new Product("Laptop", 899.99, 5);
        Product product2 = new Product("Mouse", 25.99, 10);

        double total =
            product1.calculateInventoryValue() +
            product2.calculateInventoryValue();

        System.out.println("Inventory Value: $" + total);

        JOptionPane.showMessageDialog(
            null,
            "Total Inventory Value: $" +
            String.format("%.2f", total)
        );
    }
}
