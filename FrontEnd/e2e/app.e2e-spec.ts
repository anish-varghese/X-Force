import { XForceFPage } from './app.po';

describe('x-force-f App', function() {
  let page: XForceFPage;

  beforeEach(() => {
    page = new XForceFPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
