const Sidebar = () => {
  return (
    <aside className="w-64 bg-gray-800 text-white flex flex-col h-screen">
      <div className="p-4 text-2xl font-bold border-b border-gray-700">
        Sidebar
      </div>
      <nav className="flex-1 p-4">
        <ul>
          <li className="py-2 hover:bg-gray-700 rounded">Link 1</li>
          <li className="py-2 hover:bg-gray-700 rounded">Link 2</li>
          <li className="py-2 hover:bg-gray-700 rounded">Link 3</li>
        </ul>
      </nav>
    </aside>
  );
};

export { Sidebar };
