import { Link } from "@tanstack/react-router";

const Sidebar = () => {
  return (
    <aside className="w-64 bg-gray-800 text-white flex flex-col h-screen">
      <div className="p-4 text-2xl font-bold border-b border-gray-700">
        Sidebar
      </div>
      <nav className="flex-1 p-4">
        <ul>
          <li className="py-2 hover:bg-gray-700 rounded">
            <Link to="/" className="[&.active]:font-bold block p-2">
              Home
            </Link>
          </li>
          <li className="py-2 hover:bg-gray-700 rounded">
            <Link to="/about" className="[&.active]:font-bold block p-2">
              About
            </Link>
          </li>
        </ul>
      </nav>
    </aside>
  );
};

export { Sidebar };
