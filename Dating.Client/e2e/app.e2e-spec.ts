import { Dating.ClientPage } from './app.po';

describe('dating.client App', () => {
  let page: Dating.ClientPage;

  beforeEach(() => {
    page = new Dating.ClientPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
