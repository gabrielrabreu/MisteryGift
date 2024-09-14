import { Sidebar, Header, Main, Footer } from "@/components";

const App = () => {
  return (
    <div className="flex h-screen">
      <Sidebar />
      <div className="flex-1 flex flex-col">
        <Header />
        <Main />
        <Footer />
      </div>
    </div>
  );
};

export default App;
