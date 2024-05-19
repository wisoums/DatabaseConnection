This program provides a simple console-based interface for managing SQL and Oracle database connections. It allows users to create, open, close, and execute commands on these connections while automatically handling connection timeouts.

The program maintains lists of all SQL and Oracle connections, displaying their current states and ensuring that connections are properly managed. If a connection remains open for more than a minute, it will automatically close to prevent resource leaks. This is achieved through regular timeout checks before performing any operations on the connections.

Overall, this utility is designed to streamline database connection management, making it easy to handle multiple connections and ensuring they are efficiently managed and closed when necessary.
